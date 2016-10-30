using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

namespace UDBase.Controllers.Scene {
	public class AsyncLoadHelper : MonoBehaviour {
		public float Progress { get; private set; }

		public void LoadScene(string name) {
			StartCoroutine(LoadSceneCo(name));
		}

		IEnumerator LoadSceneCo(string name) {
			yield return null;
			var operation = SceneManager.LoadSceneAsync(name);
			operation.allowSceneActivation = false;
			while (!operation.isDone && operation.progress + Mathf.Epsilon < 0.90f ) {
				Progress = operation.progress;
				yield return null;
			}
			Progress = 1.0f;
			operation.allowSceneActivation = true;
		}
	}
}
