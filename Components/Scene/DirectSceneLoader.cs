using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UDBase.Components.Scene {
	public class DirectSceneLoader : IScene {

		public void Init() {}

		public void LoadScene(ISceneInfo sceneInfo) {
			SceneManager.LoadScene(sceneInfo.Name);
		}
	}
}
