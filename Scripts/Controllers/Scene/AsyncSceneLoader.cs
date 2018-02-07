using System;
using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using Zenject;

namespace UDBase.Controllers.SceneSystem {
	public sealed class AsyncSceneLoader : IScene {
		public class BaseSettings {
			public virtual ISceneInfo LoadingSceneInfo { get; }

			public BaseSettings(ISceneInfo loadingSceneInfo = null) {
				LoadingSceneInfo = loadingSceneInfo;
			}
		}

		[Serializable]
		public class Settings : BaseSettings {
			public string LoadingScene;

			public override ISceneInfo LoadingSceneInfo {
				get {
					return GetSceneInfoByName(LoadingScene);
				}
			}

			ISceneInfo GetSceneInfoByName(string sceneName) {
				if (!string.IsNullOrEmpty(sceneName)) {
					return new SceneName(sceneName);
				}
				return null;
			}			
		}

		public ISceneInfo CurrentScene { get; private set; }

		readonly ISceneInfo _loadingScene;
		
		AsyncLoadHelper _helper;
		IEvent _events;

		public AsyncSceneLoader(IEvent events, Settings settings, AsyncLoadHelper helper) {
			_events       = events;
			_loadingScene = settings.LoadingSceneInfo;
			_helper       = helper;
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
