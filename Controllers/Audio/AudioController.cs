using UnityEngine;
using UnityEngine.Audio;
using UDBase.Controllers.LogSystem;
using System.Collections.Generic;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using Zenject;

namespace UDBase.Controllers.AudioSystem {
	public class AudioController : IAudio {
		const float MinVolume = -80.0f;
		const float MaxVolume = 0.0f;

		readonly string                    _mixerPath;
		readonly float                     _initialVolume;
		readonly string[]                  _channels;
		readonly Dictionary<string, float> _volumes = new Dictionary<string, float>();
		readonly Dictionary<string, bool>  _mutes   = new Dictionary<string, bool>();

		readonly Dictionary<string, AudioMixerGroup> _groups = new Dictionary<string, AudioMixerGroup>();

		AudioMixer _mixer;

		[Inject]
		IEvent _events;
		
		public AudioController(string mixerPath, string[] channels = null, float initialVolume = 0.5f) {
			_mixerPath     = mixerPath;
			_channels      = channels;
			_initialVolume = initialVolume;

			_mixer = Resources.Load(_mixerPath) as AudioMixer;
			if ( _mixer ) {
				Log.MessageFormat("AudioMixer loaded from '{0}'", LogTags.Audio, _mixerPath);
			} else {
				Log.ErrorFormat("AudioMixer not found at '{0}'", LogTags.Audio, _mixerPath);
			}
			UnityHelper.AddPersistantStartCallback(() => InitializeChannels());
		}

		void InitializeChannels() {
			if ( _channels != null ) {
				for ( int i = 0; i < _channels.Length; i++ ) {
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
				Log.ErrorFormat("Cannot find channel with name '{0}'", LogTags.Audio, channelName);
			}
			return group;
		}
	}
}
