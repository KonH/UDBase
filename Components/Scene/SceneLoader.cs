using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UDBase.Components.Scene {
	public class SceneLoader : IScene {

		public void Init() {}

		public void LoadScene(string sceneName) {
			SceneManager.LoadScene(sceneName);
		}
	}
}
