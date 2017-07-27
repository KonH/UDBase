﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UDBase.Controllers.SceneSystem {
	public class AsyncLoadHelper : MonoBehaviour {
		public float Progress { get; private set; }

		public void LoadScene(string sceneName) {
			StartCoroutine(LoadSceneCo(sceneName));
		}

		IEnumerator LoadSceneCo(string sceneName) {
			yield return null;
			var operation = SceneManager.LoadSceneAsync(sceneName);
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
