using System.Collections.Generic;

namespace UDBase.Controllers {
	public abstract class ControllerHelperBase {
		public abstract void Attach(IController handler);
	}

	/* Base class to make static helper for controller:
	 * Implement your controller logics in 'ControllerX' class and make ControllerHelper<T> class 'Controller'
	 * After it you can call your controller logics with 'Controller.Instance'
	 * Or you can make your own helpers like that:
	 	public static void DoSomething() {
			if ( Instance != null ) {
				Instance.DoSomething();
			}
		}
	 *
	 * Another version of controller helper provide you opportunity to use multiple instances
	 * e.g. for call method on all instances or using custom switch:
		public static void DoSomething() {
			for(int i = 0; i < Instances.Count; i++) {
				Instances[i].DoSomething();
			}
		}
	 */
	public class ControllerHelper<TController>: ControllerHelperBase where TController:IController {

		static List<TController> _instances;

		protected static List<TController> Instances { 
			get { return _instances ?? (_instances = new List<TController>()); }
		}

		protected static TController Instance { get; private set; }

		public static bool IsActive() {
			return Instance != null;
		}

		public override void Attach(IController handler) {
			var newHanlder = (TController)handler;
			Instances.Add(newHanlder);
			if( Instances.Count == 1 ) {
				Instance = newHanlder;
			}
		}
	}
}