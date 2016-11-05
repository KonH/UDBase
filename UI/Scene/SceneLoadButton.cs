using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UDBase.Controllers.SceneSystem;

namespace UDBase.Controllers.SceneSystem.UI {
	[RequireComponent(typeof(Button))]
	public class SceneLoadButton : MonoBehaviour {
		public string Name = "";

		void Start () {
			GetComponent<Button>().onClick.AddListener(OnClick);
		}

		void OnClick() {
			Scene.LoadSceneByName(Name);
		}
	}
}
