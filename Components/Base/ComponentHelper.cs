using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Components {
	public abstract class ComponentHelperBase {
		public abstract void Attach(IComponent handler);
	}

	/* Base class to make static helper for component:
	 * Implement your component logics in 'ComponentX' class and make ComponentHelper<T> class 'Component'
	 * After it you can call your component logics with 'Component.Instance'
	 * Or you can make your own helpers like that:
	 	public static void DoSomething() {
			if ( Instance != null ) {
				Instance.DoSomething();
			}
		}
	 *
	 * Another version of component helper provide you opportunity to use multiple instances
	 * e.g. for call method on all instances or using custom switch:
		public static void DoSomething() {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].DoSomething();
			}
		}
	 */
	public class ComponentHelper<TComponent>: ComponentHelperBase where TComponent:IComponent {
		static List<TComponent> _instances = null;

		public static List<TComponent> Instances { 
			get {
				if( _instances == null ) {
					_instances = new List<TComponent>();
				}
				return _instances;	
			}
		}

		public static TComponent Instance { get; private set; }

		public override void Attach(IComponent handler) {
			var newHanlder = (TComponent)handler;
			Instances.Add(newHanlder);
			if( Instances.Count == 1 ) {
				Instance = newHanlder;
			}
		}
	}
}