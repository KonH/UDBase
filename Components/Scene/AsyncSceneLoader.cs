using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UDBase.Components.Log;
using UDBase.Utils;

namespace UDBase.Components.Scene {
	public class AsyncSceneLoader : IScene {
		AsyncLoadHelper _helper       = null;
		string          _loadingScene = "";

		public AsyncSceneLoader(string loadingScene = "") {
			_loadingScene = loadingScene;
		}

		public void Init() {
			_helper = UnityHelper.AddPersistant<AsyncLoadHelper>();
		}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				TryLoadLoadingScene(sceneInfo); 
				_helper.LoadScene(sceneName);
			} else {
				Log.Log.ErrorFormat("Scene not found: \"{0}\" via {1}", LogTags.Scene, sceneName, sceneInfo);
			}
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
