using UnityEngine;
using Zenject;

namespace UDBase.UI.Common {
	public class OverlayFactory : Factory<GameObject, UIOverlay> { }

	public class CustomOverlayFactory : IFactory<GameObject, UIOverlay> {

		DiContainer _container;

		public CustomOverlayFactory(DiContainer container) {
			_container = container;
		}

		public UIOverlay Create(GameObject prefab) {
			var instance = _container.InstantiatePrefab(prefab);
			return instance.GetComponent<UIOverlay>();
		}
	}
}
