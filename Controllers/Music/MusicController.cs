using UDBase.Utils;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SceneSystem;

namespace UDBase.Controllers.MusicSystem {
	public class MusicController : IMusic {
		MusicUtility _utility;

		public void Init() {
			_utility = UnityHelper.AddPersistant<MusicUtility>(true);
		}

		public void PostInit() {
			Events.Subscribe<Scene_Loaded>(this, OnSceneLoaded);
			UpdateCurrentTrack();
		}

		public void Reset() {
			Events.Unsubscribe<Scene_Loaded>(OnSceneLoaded);
		}

		void OnSceneLoaded(Scene_Loaded e) {
			UpdateCurrentTrack();
		}

		void UpdateCurrentTrack() {
			_utility.StopTrack();
			_utility.SetupTrack();
		}

		public void Pause() {
			_utility.Pause();
		}

		public void UnPause() {
			_utility.UnPause();
		}
	}
}