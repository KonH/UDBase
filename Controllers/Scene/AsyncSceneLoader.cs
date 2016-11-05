using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;

namespace UDBase.Controllers.SceneSystem {
	public sealed class AsyncSceneLoader : IScene {
		AsyncLoadHelper _helper       = null;
		ISceneInfo      _loadingScene = null;
		ISceneInfo      _firstScene   = null;

		public AsyncSceneLoader(string loadingSceneName = null, string firstSceneName = null) {
			_loadingScene = new SceneName(loadingSceneName);
			_firstScene   = new SceneName(firstSceneName);
		}

		public AsyncSceneLoader(ISceneInfo loadingScene = null, ISceneInfo firstScene = null) {
			_loadingScene = loadingScene;
			_firstScene   = firstScene;
		}

		public void Init() {
			_helper = UnityHelper.AddPersistant<AsyncLoadHelper>();
			if( _firstScene != null ) {
				LoadScene(_firstScene);
			}
		}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				TryLoadLoadingScene(sceneInfo); 
				_helper.LoadScene(sceneName);
			} else {
				Log.ErrorFormat("Scene not found: \"{0}\" via {1}", LogTags.Scene, sceneName, sceneInfo);
			}
		}

		void TryLoadLoadingScene(ISceneInfo sceneInfo) {
			var sceneName = GetLoadingSceneName(sceneInfo);
			if( !string.IsNullOrEmpty(sceneName) ) {
				SceneManager.LoadScene(sceneName);
			}
		}

		string GetLoadingSceneName(ISceneInfo sceneInfo) {
			return _loadingScene != null ? _loadingScene.Name : "";
		}
	}
}
