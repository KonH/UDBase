using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UDBase.Utils;

namespace UDBase.Controllers.SceneSystem {
	public class AsyncLoadHelper : MonoBehaviour {
		public float Progress { get; private set; }

		Action _loadCallback;

		void Start() {
			SceneManager.activeSceneChanged += OnSceneChanged;
		}

		void OnDestroy() {
			SceneManager.activeSceneChanged -= OnSceneChanged;
		}

		void OnSceneChanged(UnityEngine.SceneManagement.Scene scene0, UnityEngine.SceneManagement.Scene scene1) {
			if ( _loadCallback != null ) {
				_loadCallback();
			}
		}

		public void LoadScene(string sceneName, Action callback) {
			_loadCallback = callback;
			StartCoroutine(LoadSceneCoroutine(sceneName));
		}

		IEnumerator LoadSceneCoroutine(string sceneName) {
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
