namespace UDBase.Controllers.MusicSystem {

	/// <summary>
	/// IMusic is a music playing system.
	/// It doesn't provide methods to play, because by default it controlled by MusicHolder on scene.
	/// </summary>
	public interface IMusic {

		/// <summary>
		/// Pause current track
		/// </summary>
		void Pause();

		/// <summary>
		/// Resume current track
		/// </summary>
		void UnPause();
	}
}