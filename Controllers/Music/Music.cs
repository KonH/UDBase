namespace UDBase.Controllers.MusicSystem {
	public class Music : ControllerHelper<MusicController> {
		public void Pause() {
			if ( Instance != null ) {
				Instance.Pause();
			}
		}

		public void UpPause() {
			if ( Instance != null ) {
				Instance.UnPause();
			}
		}
	}
}
