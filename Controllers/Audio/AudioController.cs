using UnityEngine;
using UnityEngine.Audio;
using UDBase.Controllers.LogSystem;
using System.Collections.Generic;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;

namespace UDBase.Controllers.AudioSystem {
	public class AudioController : IAudio {

		const float MinVolume = -80.0f;
		const float MaxVolume = 0.0f;

		string                    _mixerPath     = null;
		float                     _initialVolume = 0.0f;
		string[]                  _channels      = null;
		AudioMixer                _mixer         = null;
		Dictionary<string, float> _volumes       = new Dictionary<string, float>();
		Dictionary<string, bool>  _mutes         = new Dictionary<string, bool>();

		public AudioController(string mixerPath, float initialVolume = 0.5f, string[] channels = null) {
			_channels      = channels;
			_mixerPath     = mixerPath;
			_initialVolume = initialVolume;
		}

		public void Init() {
			_mixer = Resources.Load(_mixerPath) as AudioMixer;
			if ( _mixer ) {
				Log.MessageFormat("AudioMixer loaded from '{0}'", LogTags.Audio, _mixerPath);
			} else {
				Log.ErrorFormat("AudioMixer not found at '{0}'", LogTags.Audio, _mixerPath);
			}
		}

		public void PostInit() {
			UnityHelper.AddPersistantStartCallback(() => InitializeChannels());
		}

		void InitializeChannels() {
			if ( _channels != null ) {
				for ( int i = 0; i < _channels.Length; i++ ) {
					SetChannelVolume(_channels[i], _initialVolume);
				}
			}
		}

		public void Reset() {}

		public void MuteChannel(string parameter) {
			UpdateMute(parameter, true);
			UpdateChannel(parameter);
		}

		public void UnMuteChannel(string parameter) {
			UpdateMute(parameter, false);
			if ( Mathf.Approximately(FindVolume(parameter), 0.0f) ) {
				ResetVolume(parameter);
			}
			UpdateChannel(parameter);
		}

		public float GetChannelVolume(string parameter) {
			return FindMute(parameter) ? 0.0f : FindVolume(parameter);
		}

		public bool IsChannelMuted(string parameter) {
			return FindMute(parameter) || FindVolume(parameter) == 0.0f;
		}

		public void ToggleChannel(string parameter) {
			if ( IsChannelMuted(parameter) ) {
				UnMuteChannel(parameter);
			} else {
				MuteChannel(parameter);
			}
		}

		public void SetChannelVolume(string parameter, float normalizedVolume) {
			UpdateVolume(parameter, normalizedVolume);
			UpdateChannel(parameter);
		}

		void EnsureVolume(string parameter) {
			if ( !_volumes.ContainsKey(parameter) ) {
				var realVolume = 0.0f;
				if ( _mixer ) {
					_mixer.GetFloat(parameter, out realVolume);
				}
				var realVolumeNormalized = Mathf.InverseLerp(MinVolume, MaxVolume, realVolume);
				_volumes.Add(parameter, realVolumeNormalized);
			}
		}

		void UpdateVolume(string parameter, float normalizedVolume) {
			EnsureVolume(parameter);
			_volumes[parameter] = normalizedVolume;
		}

		float FindVolume(string parameter) {
			EnsureVolume(parameter);
			return _volumes[parameter];
		}

		void EnsureMute(string parameter) {
			if ( !_mutes.ContainsKey(parameter) ) {
				_mutes.Add(parameter, false);
			}
		}

		void UpdateMute(string parameter, bool mute) {
			EnsureMute(parameter);
			_mutes[parameter] = mute;
		}

		bool FindMute(string parameter) {
			EnsureMute(parameter);
			return _mutes[parameter];
		}

		void ResetVolume(string parameter) {
			_volumes[parameter] = _initialVolume;
		}

		float VolumeDecorator(float normalizedVolume, bool muted) {
			return muted ? MinVolume : Mathf.Lerp(MinVolume, MaxVolume, normalizedVolume);
		}

		void UpdateChannel(string parameter) {
			var volume = FindVolume(parameter);
			var mute = FindMute(parameter);
			if ( _mixer ) {
				_mixer.SetFloat(parameter, VolumeDecorator(volume, mute));
			}
			OnVolumeChanged(parameter);
		}

		void OnVolumeChanged(string parameter) {
			Events.Fire(new VolumeChangeEvent(parameter, GetChannelVolume(parameter)));
		}
	}
}
