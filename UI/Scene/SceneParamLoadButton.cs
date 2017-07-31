using UDBase.UI.Common;

namespace UDBase.Controllers.SceneSystem.UI {
	public class SceneParamLoadButton<T> : ActionButton {
		public T      Type;
		public string Param = "";

		public override bool IsVisible() { 
			return true; 
		}

		public override bool IsInteractable() {
			return true;
		}

		public override void OnClick() {
			Scene.LoadScene(Type, Param);
		}
	}
}
