using UDBase.UI.Common;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
	/// <summary>
	/// Base ActionButton to load scene by typed parameter via IScene controller 
	/// </summary>
	public abstract class SceneParamLoadButton<T> : ActionButton {
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
