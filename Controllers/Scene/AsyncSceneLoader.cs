using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using Zenject;

namespace UDBase.Controllers.SceneSystem {
	public sealed class AsyncSceneLoader : IScene {
		public class SceneSetup {
			public ISceneInfo LoadingScene { get; }
			public ISceneInfo FirstScene   { get; }

			public SceneSetup(ISceneInfo loadingScene = null, ISceneInfo firtsScene = null) {
				LoadingScene = loadingScene;
				FirstScene   = firtsScene;
			}

			public SceneSetup(string loadingSceneName = null, string firtsSceneName = null) {
				if ( loadingSceneName != null ) {
                    LoadingScene = new SceneName(loadingSceneName);
                }
				if ( firtsSceneName != null ) {
					FirstScene = new SceneName(firtsSceneName);
				}
			}
		}

		public ISceneInfo CurrentScene { get; private set; }

		readonly ISceneInfo _loadingScene;
		readonly ISceneInfo _firstScene;
		
		AsyncLoadHelper _helper;

		SceneSetup _setup;
		IEvent _events;

		public AsyncSceneLoader(IEvent events, SceneSetup setup, AsyncLoadHelper helper) {
			_events       = events;
			_loadingScene = setup.LoadingScene;
			_firstScene   = setup.FirstScene;
			_helper       = helper;
			if( (_firstScene != null) && !string.IsNullOrEmpty(_firstScene.Name) ) {
				LoadScene(_firstScene);
			}
		}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			TryOpenLoadingScene();
			_helper.LoadScene(sceneName, () => {
				CurrentScene = sceneInfo;
				_events.Fire(new Scene_Loaded(sceneInfo));
			});
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

		void TryOpenLoadingScene() {
			var sceneName = GetLoadingSceneName();
			if( !string.IsNullOrEmpty(sceneName) ) {
				SceneManager.LoadScene(sceneName);
			}
		}

		string GetLoadingSceneName() {
			return (_loadingScene != null) ? _loadingScene.Name : "";
		}
	}
}
