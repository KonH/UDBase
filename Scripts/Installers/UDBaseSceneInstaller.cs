using UnityEngine;
using UDBase.UI.Common;

namespace UDBase.Installers {
	/// <summary>
	/// Installer for UDBase components with scene-based life-cycle
	/// </summary>
	[AddComponentMenu("UDBase/Installers/SceneInstaller")]
    public class UDBaseSceneInstaller : UDBaseInstaller {

		public UIManager.Settings UISettings;

		public void AddUIManager(UIManager.Settings settings) {
			Container.BindFactory<GameObject, UIOverlay, OverlayFactory>().FromFactory<CustomOverlayFactory>();
			Container.BindInstance(settings);
			Container.Bind<UIManager>().FromNewComponentOnNewGameObject().AsSingle();
		}

		public override void InstallBindings() {
			AddUIManager(UISettings);
		}
	}
}