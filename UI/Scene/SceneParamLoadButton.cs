using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace UDBase.Controllers.SceneSystem.UI {
	public class SceneParamLoadButton<T> : MonoBehaviour {
		public T      Type  = default(T);
		public string Param = "";

		void Start () {
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		void OnClick() {
			Scene.LoadScene(Type, Param);
		}
	}
}
