using UDBase.Utils;
using UDBase.Common;
using UDBase.Controllers.UTime;
using UDBase.Controllers.LogSystem;
using UnityEngine;
using UDBase.UI.Common;

namespace UDBase.Installers {
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