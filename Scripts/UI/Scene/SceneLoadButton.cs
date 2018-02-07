using UDBase.UI.Common;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
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
