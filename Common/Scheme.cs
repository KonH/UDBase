using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Components;

namespace UDBase.Common {
	/* If you want some combination of components you need to inherit from that class
	 * add call AddComponent for required components
	 */
	public abstract class Scheme : IScheme {
		Dictionary<IComponent, ComponentHelperBase> _components = new Dictionary<IComponent, ComponentHelperBase>();

		public void AddComponent(ComponentHelperBase helper, IComponent component) {
			_components.Add(component, helper);
		}
			
		public void AddComponents<T>(CompositeHelper<T> helper, params IComponent[] components) where T:IComponent {
			for(int i = 0; i < components.Length; i++) {
				_components.Add(components[i], helper);
			}
		}

		public void Init()
		{
			var iter = _components.GetEnumerator();
			while(iter.MoveNext()) {
				var component = iter.Current.Key;
				component.Init();
				var helper = iter.Current.Value;
				helper.Attach(component);
			}
		}
	}
}
