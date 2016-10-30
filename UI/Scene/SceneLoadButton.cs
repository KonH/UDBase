using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UDBase.Controllers.Scene;

namespace UDBase.Controllers.Scene.UI {
	[RequireComponent(typeof(Button))]
	public class SceneLoadButton : MonoBehaviour {
		public string Name = "";

		void Start () {
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		void OnClick() {
			Scene.LoadSceneInfo(new SceneName(Name));
		}
	}
}
