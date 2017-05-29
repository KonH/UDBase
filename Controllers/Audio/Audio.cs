namespace UDBase.Controllers.AudioSystem {
	public class Audio : ControllerHelper<IAudio> {

		public const string Default_Sound_Channel_Volume = "SoundVolume";
		public const string Default_Music_Channel_Volume = "MusicVolume";

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
			MuteChannel(Default_Sound_Channel_Volume);
		}

		public static void UnMuteSound() {
			UnMuteChannel(Default_Sound_Channel_Volume);
		}

		public static void ToggleSound() {
			ToggleChannel(Default_Sound_Channel_Volume);
		}

		public static float GetSoundVolume() {
			return GetChannelVolume(Default_Sound_Channel_Volume);
		}

		public static bool IsSoundMuted() {
			return IsChannelMuted(Default_Sound_Channel_Volume);
		}

		public static void SetSoundVolume(float normalizedVolume) {
			SetChannelVolume(Default_Sound_Channel_Volume, normalizedVolume);
		}

		public static void MuteMusic() {
			MuteChannel(Default_Music_Channel_Volume);
		}

		public static void UnMuteMusic() {
			UnMuteChannel(Default_Music_Channel_Volume);
		}

		public static void ToggleMusic() {
			ToggleChannel(Default_Music_Channel_Volume);
		}

		public static float GetMusicVolume() {
			return GetChannelVolume(Default_Music_Channel_Volume);
		}

		public static bool IsMusicMuted() {
			return IsChannelMuted(Default_Music_Channel_Volume);
		}

		public static void SetMusicVolume(float normalizedVolume) {
			SetChannelVolume(Default_Music_Channel_Volume, normalizedVolume);
		}
	}
}
