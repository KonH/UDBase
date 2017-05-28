using UnityEngine;
using UnityEngine.Audio;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.AudioSystem {
	public class AudioController : IAudio {

		const float MinVolume = -80.0f;
		const float MaxVolume = 0.0f;

		string     _mixerPath = null;
		AudioMixer _mixer     = null;

		public AudioController(string mixerPath) {
			_mixerPath = mixerPath;
		}

		public void Init() {
			_mixer = Resources.Load(_mixerPath) as AudioMixer;
			if ( _mixer ) {
				Log.MessageFormat("AudioMixer loaded from '{0}'", LogTags.Audio, _mixerPath);
			} else {
				Log.ErrorFormat("AudioMixer not found at '{0}'", LogTags.Audio, _mixerPath);
			}
		}

		public void PostInit() {}

		public void Reset() {}

		public void MuteChannel(string parameter) {
			if ( _mixer != null ) {
				_mixer.SetFloat(parameter, MinVolume);
			}
		}

		public void UnMuteChannel(string parameter) {
			if ( _mixer != null ) {
				_mixer.SetFloat(parameter, MaxVolume);
			}
		}

		bool IsChannelMuted(string parameter) {
			if ( _mixer != null ) {
				var value = 0.0f;
				_mixer.GetFloat(parameter, out value);
				return Mathf.Approximately(value, MinVolume);
			}
			return false;
		}

		public void ToggleChannel(string parameter) {
			if ( IsChannelMuted(parameter) ) {
				UnMuteChannel(parameter);
			} else {
				MuteChannel(parameter);
			}
		}
	}
}
