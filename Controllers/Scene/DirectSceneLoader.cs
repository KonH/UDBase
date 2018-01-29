using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.SceneSystem {
	public sealed class DirectSceneLoader : IScene {
		public ISceneInfo CurrentScene { get; private set; }

		IEvent _events;

		public DirectSceneLoader(IEvent events) {
			_events = events;
		}

		public void Init() {}

		public void PostInit() {}

		public void Reset() {}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				SceneManager.LoadScene(sceneName);
				CurrentScene = sceneInfo;
				_events.Fire(new Scene_Loaded(sceneInfo));
			} else {
				Log.ErrorFormat("Scene not found: \"{0}\" via {1}", LogTags.Scene, sceneName, sceneInfo);
			}
		}

		public void ReloadScene() {
			if( CurrentScene == null ) {
				CurrentScene = new SceneName(SceneManager.GetActiveScene().name);
			}
			LoadScene(CurrentScene);
		}
	}
}
