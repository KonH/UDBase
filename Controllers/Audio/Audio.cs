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

		public static void ToggleChannel(string parameter) {
			if ( Instance != null ) {
				Instance.ToggleChannel(parameter);
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

		public static void MuteMusic() {
			MuteChannel(Default_Music_Channel_Volume);
		}

		public static void UnMuteMusic() {
			UnMuteChannel(Default_Music_Channel_Volume);
		}

		public static void ToggleMusic() {
			ToggleChannel(Default_Music_Channel_Volume);
		}
	}
}
