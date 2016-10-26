using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UDBase.Utils;

namespace UDBase.Components.Scene {
	public class AsyncSceneLoader : IScene {
		AsyncLoadHelper _helper       = null;
		string          _loadingScene = "";

		public AsyncSceneLoader(string loadingScene = "") {
			_loadingScene = loadingScene;
		}

		public void Init() {
			_helper = ResourcesLoader.AddPersistant<AsyncLoadHelper>();
		}

		public void LoadScene(ISceneInfo sceneInfo) {
			TryLoadLoadingScene(sceneInfo); 
			_helper.LoadScene(sceneInfo.Name);
		}

		void TryLoadLoadingScene(ISceneInfo sceneInfo) {
			var sceneName = GetLoadingSceneName(sceneInfo);
			if( !string.IsNullOrEmpty(sceneName) ) {
				SceneManager.LoadScene(sceneName);
			}
		}

		protected virtual string GetLoadingSceneName(ISceneInfo sceneInfo) {
			return _loadingScene;
		}
	}
}
