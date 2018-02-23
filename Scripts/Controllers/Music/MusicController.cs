using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SceneSystem;

namespace UDBase.Controllers.MusicSystem {

	/// <summary>
	/// Default music controller.
	/// For use it, you need to add to scene where you need music MusicHolder with assigned list of SoundSource,
	/// represented wanted music tracks.
	/// </summary>
	public class MusicController : IMusic {
		MusicUtility _utility;
		bool         _paused;

		public MusicController(MusicUtility utility, IEvent events) {
			_utility = utility;
			events.Subscribe<Scene_Loaded>(this, OnSceneLoaded);
			UpdateCurrentTrack();
		}

		void OnSceneLoaded(Scene_Loaded e) {
			UpdateCurrentTrack();
		}

		void UpdateCurrentTrack() {
			_utility.StopTrack();
			_utility.SetupTrack();
			if ( _paused ) {
				_utility.Pause();
			}
		}

		public void Pause() {
			_utility.Pause();
			_paused = true;
		}

		public void UnPause() {
			_utility.UnPause();
			_paused = false;
		}
	}
}