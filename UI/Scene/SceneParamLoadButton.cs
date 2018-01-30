using UDBase.UI.Common;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
	public class SceneParamLoadButton<T> : ActionButton {
		public T      Type;
		public string Param = "";

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
			_scene.LoadScene(Type, Param);
		}
	}
}
