using System;
using UnityEngine;
using UnityEngine.Audio;
using UDBase.Controllers.LogSystem;
using System.Collections.Generic;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;

namespace UDBase.Controllers.AudioSystem {
	public class AudioController : IAudio, ILogContext {
		const float MinVolume = -80.0f;
		const float MaxVolume = 0.0f;

		[Serializable]
		public class Settings {
			public string MixerPath;
			public List<string> Channels;
			public float InitialVolume;
		}

		readonly string                    _mixerPath;
		readonly float                     _initialVolume;
		readonly List<string>              _channels;
		readonly Dictionary<string, float> _volumes = new Dictionary<string, float>();
		readonly Dictionary<string, bool>  _mutes   = new Dictionary<string, bool>();

		readonly Dictionary<string, AudioMixerGroup> _groups = new Dictionary<string, AudioMixerGroup>();

		AudioMixer _mixer;

		ILog _log;
		IEvent _events;
		
		public AudioController(Settings settings, ILog log, IEvent events) {
			_log           = log;
			_events        = events;
			_mixerPath     = settings.MixerPath;
			_channels      = settings.Channels;
			_initialVolume = settings.InitialVolume;

			_mixer = Resources.Load(_mixerPath) as AudioMixer;
			if ( _mixer ) {
				_log.MessageFormat(this, "AudioMixer loaded from '{0}'", _mixerPath);
			} else {
				_log.ErrorFormat(this, "AudioMixer not found at '{0}'", _mixerPath);
			}
			UnityHelper.AddPersistantStartCallback(() => InitializeChannels());
		}

		void InitializeChannels() {
			if ( _channels != null ) {
				for ( int i = 0; i < _channels.Count; i++ ) {
					SetChannelVolume(_channels[i], _initialVolume);
				}
			}
		}

		public void MuteChannel(string channelParam) {
			UpdateMute(channelParam, true);
			UpdateChannel(channelParam);
		}

		public void UnMuteChannel(string channelParam) {
			UpdateMute(channelParam, false);
			if ( Mathf.Approximately(FindVolume(channelParam), 0.0f) ) {
				ResetVolume(channelParam);
			}
			UpdateChannel(channelParam);
		}

		public float GetChannelVolume(string channelParam) {
			return FindMute(channelParam) ? 0.0f : FindVolume(channelParam);
		}

		public bool IsChannelMuted(string channelParam) {
			return FindMute(channelParam) || Mathf.Approximately(FindVolume(channelParam), 0.0f);
		}

		public void ToggleChannel(string channelParam) {
			if ( IsChannelMuted(channelParam) ) {
				UnMuteChannel(channelParam);
			} else {
				MuteChannel(channelParam);
			}
		}

		public void SetChannelVolume(string channelParam, float normalizedVolume) {
			UpdateVolume(channelParam, normalizedVolume);
			UpdateChannel(channelParam);
		}

		void EnsureVolume(string channelParam) {
			if ( !_volumes.ContainsKey(channelParam) ) {
				var realVolume = 0.0f;
				if ( _mixer ) {
					_mixer.GetFloat(channelParam, out realVolume);
				}
				var realVolumeNormalized = Mathf.InverseLerp(MinVolume, MaxVolume, realVolume);
				_volumes.Add(channelParam, realVolumeNormalized);
			}
		}

		void UpdateVolume(string channelParam, float normalizedVolume) {
			EnsureVolume(channelParam);
			_volumes[channelParam] = normalizedVolume;
		}

		float FindVolume(string channelParam) {
			EnsureVolume(channelParam);
			return _volumes[channelParam];
		}

		void EnsureMute(string channelParam) {
			if ( !_mutes.ContainsKey(channelParam) ) {
				_mutes.Add(channelParam, false);
			}
		}

		void UpdateMute(string channelParam, bool mute) {
			EnsureMute(channelParam);
			_mutes[channelParam] = mute;
		}

		bool FindMute(string channelParam) {
			EnsureMute(channelParam);
			return _mutes[channelParam];
		}

		void ResetVolume(string channelParam) {
			_volumes[channelParam] = _initialVolume;
		}

		float VolumeDecorator(float normalizedVolume, bool muted) {
			return muted ? MinVolume : Mathf.Lerp(MinVolume, MaxVolume, normalizedVolume);
		}

		void UpdateChannel(string channelParam) {
			var volume = FindVolume(channelParam);
			var mute = FindMute(channelParam);
			if ( _mixer ) {
				_mixer.SetFloat(channelParam, VolumeDecorator(volume, mute));
			}
			OnVolumeChanged(channelParam);
		}

		void OnVolumeChanged(string channelParam) {
			_events.Fire(new VolumeChangeEvent(channelParam, GetChannelVolume(channelParam)));
		}

		bool GetMixerGroupFast(string channelName, out AudioMixerGroup result) {
			return _groups.TryGetValue(channelName, out result);
		} 

		public AudioMixerGroup GetMixerGroup(string channelName) {
			AudioMixerGroup group;
			if ( !GetMixerGroupFast(channelName, out group) ) {
				if ( _mixer != null ) {
					var results = _mixer.FindMatchingGroups(channelName);
					if ( results.Length > 0 ) {
						group = results[0];
					}
				}
				_groups.Add(channelName, group);
			}
			if ( !group ) {
				_log.ErrorFormat(this, "Cannot find channel with name '{0}'", channelName);
			}
			return group;
		}
	}
}
