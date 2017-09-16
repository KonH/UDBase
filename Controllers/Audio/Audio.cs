using UnityEngine.Audio;

namespace UDBase.Controllers.AudioSystem {
	public class Audio : ControllerHelper<IAudio> {

		public const string DefaultSoundChannelVolume = "SoundVolume";
		public const string DefaultMusicChannelVolume = "MusicVolume";
		public const string DefaultSoundChannelName   = "Sound";
		public const string DefaultMusicChannelName   = "Music";

		public static void MuteChannel(string parameter) {
			if ( Instance != null ) {
				Instance.MuteChannel(parameter);
			}
		}

		public static void UnMuteChannel(string parameter) {
			if ( Instance != null ) {
				Instance.UnMuteChannel(parameter);
			}
		}

		public static float GetChannelVolume(string parameter) {
			if ( Instance != null ) {
				return Instance.GetChannelVolume(parameter);
			}
			return 0.0f;
		}

		public static bool IsChannelMuted(string parameter) {
			if ( Instance != null ) {
				return Instance.IsChannelMuted(parameter);
			}
			return false;
		}

		public static void ToggleChannel(string parameter) {
			if ( Instance != null ) {
				Instance.ToggleChannel(parameter);
			}
		}

		public static void SetChannelVolume(string parameter, float normalizedVolume) {
			if ( Instance != null ) {
				Instance.SetChannelVolume(parameter, normalizedVolume);
			}
		}

		public static void MuteSound() {
			MuteChannel(DefaultSoundChannelVolume);
		}

		public static void UnMuteSound() {
			UnMuteChannel(DefaultSoundChannelVolume);
		}

		public static void ToggleSound() {
			ToggleChannel(DefaultSoundChannelVolume);
		}

		public static float GetSoundVolume() {
			return GetChannelVolume(DefaultSoundChannelVolume);
		}

		public static bool IsSoundMuted() {
			return IsChannelMuted(DefaultSoundChannelVolume);
		}

		public static void SetSoundVolume(float normalizedVolume) {
			SetChannelVolume(DefaultSoundChannelVolume, normalizedVolume);
		}

		public static void MuteMusic() {
			MuteChannel(DefaultMusicChannelVolume);
		}

		public static void UnMuteMusic() {
			UnMuteChannel(DefaultMusicChannelVolume);
		}

		public static void ToggleMusic() {
			ToggleChannel(DefaultMusicChannelVolume);
		}

		public static float GetMusicVolume() {
			return GetChannelVolume(DefaultMusicChannelVolume);
		}

		public static bool IsMusicMuted() {
			return IsChannelMuted(DefaultMusicChannelVolume);
		}

		public static void SetMusicVolume(float normalizedVolume) {
			SetChannelVolume(DefaultMusicChannelVolume, normalizedVolume);
		}

		public static AudioMixerGroup GetMixerGroup(string channelName) {
			if ( Instance != null ) {
				return Instance.GetMixerGroup(channelName);
			}
			return null;
		}
	}
}
