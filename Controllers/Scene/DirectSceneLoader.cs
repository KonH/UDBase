using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.SceneSystem {
	public class DirectSceneLoader : IScene {

		public void Init() {}

		public void LoadScene(ISceneInfo sceneInfo) {
			var sceneName = sceneInfo.Name;
			if( Scene.IsSceneNameValid(sceneName) ) {
				SceneManager.LoadScene(sceneName);
			} else {
				Log.ErrorFormat("Scene not found: \"{0}\" via {1}", LogTags.Scene, sceneName, sceneInfo);
			}
		}
	}
}
