using UnityEngine;
using System.Collections;

namespace UDBase.Components {
	
	/* Base class to make static helper for component:
	 * Implement your component logics in 'ComponentX' class and make ComponentHelper<T> class 'Component'
	 * After it you can call your component logics with 'Component.Instance'
	 * Or you can make your own helpers like that:
	 	public static void DoSomething() {
			if ( Instance != null ) {
				Instance.DoSomething();
			}
		} 
	*/
	public abstract class ComponentHelperBase {
		public abstract void Attach(IComponent handler);
	}

	public class ComponentHelper<TComponent>: ComponentHelperBase where TComponent:IComponent {
		public static TComponent Instance { get; private set; }

		public override void Attach(IComponent handler) {
			Instance = (TComponent)handler;
		}
	}
}