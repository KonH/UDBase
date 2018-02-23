using UnityEngine.SceneManagement;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.SceneSystem {

	/// <summary>
	/// Synchronous scene loader 
	/// </summary>
	public sealed class DirectSceneLoader : IScene {
		public ISceneInfo CurrentScene { get; private set; }

		IEvent _events;

		public DirectSceneLoader(IEvent events) {
			_events = events;
		}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			SceneManager.LoadScene(sceneName);
			CurrentScene = sceneInfo;
			_events.Fire(new Scene_Loaded(sceneInfo));
		}

		public void LoadScene(string sceneName) {
			LoadScene(new SceneName(sceneName));
		}
		public void LoadScene<T>(T type) {
			LoadScene(SceneInfo.Get(type));
		}
		public void LoadScene<T>(T type, string param) {
			LoadScene(SceneInfo.Get(type, param));
		}
		public void LoadScene<T>(T type, params string[] parameters) {
			LoadScene(SceneInfo.Get(type, parameters));
		}

		public void ReloadScene() {
			if( CurrentScene == null ) {
				CurrentScene = new SceneName(SceneManager.GetActiveScene().name);
			}
			LoadScene(CurrentScene);
		}
	}
}
