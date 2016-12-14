using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.SceneSystem {
	public sealed class DirectSceneLoader : IScene {

		public ISceneInfo CurrentScene { get; private set; }

		public void Init() {}

		public void PostInit() {}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				SceneManager.LoadScene(sceneName);
				CurrentScene = sceneInfo;
				Events.Fire<Scene_Loaded>(new Scene_Loaded(sceneInfo));
			} else {
				Log.ErrorFormat("Scene not found: \"{0}\" via {1}", LogTags.Scene, sceneName, sceneInfo);
			}
		}

		public void ReloadScene() {
			LoadScene(CurrentScene);
		}
	}
}
