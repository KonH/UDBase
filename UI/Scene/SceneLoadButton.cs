using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UDBase.UI.Common;

namespace UDBase.Controllers.SceneSystem.UI {
	public class SceneLoadButton : ActionButton {
		public string Name = "";

		public override bool IsVisible() { 
			return true; 
		}

		public override bool IsInteractable() {
			return true;
		}

		public override void OnClick() {
			Scene.LoadSceneByName(Name);
		}
	}
}
