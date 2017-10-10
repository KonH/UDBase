namespace UDBase.Controllers.MusicSystem {
	public class Music : ControllerHelper<MusicController> {
		public static void Pause() {
			if ( Instance != null ) {
				Instance.Pause();
			}
		}

		public static void UnPause() {
			if ( Instance != null ) {
				Instance.UnPause();
			}
		}
	}
}
