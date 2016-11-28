using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers;

namespace UDBase.Common {
	/* If you want some combination of components you need to inherit from that class
	 * add call AddComponent for required components
	 */
	public abstract class Scheme : IScheme {
		Dictionary<IController, ControllerHelperBase> _components = new Dictionary<IController, ControllerHelperBase>();

		public void AddController(ControllerHelperBase helper, params IController[] components) {
			for(int i = 0; i < components.Length; i++) {
				_components.Add(components[i], helper);
			}
		}

		public void AddController<THelper>(params IController[] components) 
			where THelper:ControllerHelperBase, new() {
			var helper = new THelper();
			for(int i = 0; i < components.Length; i++) {
				_components.Add(components[i], helper);
			}
		}
			
		public void Init() {
			var iter = _components.GetEnumerator();
			while(iter.MoveNext()) {
				var component = iter.Current.Key;
				component.Init();
				var helper = iter.Current.Value;
				helper.Attach(component);
			}
		}

		public void PostInit() {
			var iter = _components.GetEnumerator();
			while(iter.MoveNext()) {
				var component = iter.Current.Key;
				component.PostInit();
			}
		}
	}
}
