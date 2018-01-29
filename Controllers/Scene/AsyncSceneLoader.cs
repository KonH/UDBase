using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using Zenject;

namespace UDBase.Controllers.SceneSystem {
	public sealed class AsyncSceneLoader : IScene {
		public ISceneInfo CurrentScene { get; private set; }

		readonly ISceneInfo _loadingScene;
		readonly ISceneInfo _firstScene;
		
		AsyncLoadHelper _helper;

		[Inject]
		IEvent _events;		

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
			if( (_firstScene != null) && !string.IsNullOrEmpty(_firstScene.Name) ) {
				LoadScene(_firstScene);
			}
		}

		public void PostInit() {}

		public void Reset() {}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				TryLoadLoadingScene();
				_helper.LoadScene(sceneName, () => {
					CurrentScene = sceneInfo;
					_events.Fire(new Scene_Loaded(sceneInfo));
				});
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

		void TryLoadLoadingScene() {
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
