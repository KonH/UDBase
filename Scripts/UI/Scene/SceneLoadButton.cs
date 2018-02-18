using UnityEngine;
using UDBase.UI.Common;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
	/// <summary>
	/// ActionButton to load scene by name via IScene component
	/// </summary>
	[AddComponentMenu("UDBase/UI/Scene/SceneLoadButton")]
	public class SceneLoadButton : ActionButton {
		public string Name = "";

		IScene _scene;

		[Inject]
		public void Init(IScene scene) {
			_scene = scene;
		}

		public override bool IsVisible() { 
			return true; 
		}

		public override bool IsInteractable() {
			return true;
		}

		public override void OnClick() {
			_scene.LoadScene(Name);
		}
	}
}
