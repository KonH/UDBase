using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers;

namespace UDBase.Common {
	/// <summary>
	/// Scheme. If you want some combination of components you need to inherit from that class
	/// add call AddComponent for required components
	/// Note: This class used native Debug messages (Log controller is unreachable yet)
	/// </summary>
	public abstract class Scheme : IScheme {
		Dictionary<IController, ControllerHelperBase> _controllers = new Dictionary<IController, ControllerHelperBase>();

		public void AddController(ControllerHelperBase helper, params IController[] controllers) {
			if( helper == null ) {
				Debug.LogError("Helper can't be null!");
				return;
			}
			if( (controllers == null) || (controllers.Length == 0) ) {
				Debug.LogError("Controllers can't be null or empty!");
				return;
			}
			for(int i = 0; i < controllers.Length; i++) {
				if( controllers[i] != null ) {
					_controllers.Add(controllers[i], helper);
				} else {
					Debug.LogWarning("Can't add null controler.");
				}
			}
		}

		public bool HasController(IController controller) {
			if( controller != null ) {
				return _controllers.ContainsKey(controller);
			}
			return false;
		}

		public ControllerHelperBase GetControllerHelper(IController controller) {
			var helper = default(ControllerHelperBase);
			if( controller != null ) {
				_controllers.TryGetValue(controller, out helper);
			} 
			return helper;
		}

		public bool HasControllerHelper(IController controller) {
			return GetControllerHelper(controller) != null;
		}

		public void Init() {
			var iter = _controllers.GetEnumerator();
			while(iter.MoveNext()) {
				var controller = iter.Current.Key;
				controller.Init();
				var helper = iter.Current.Value;
				helper.Attach(controller);
			}
		}
	}
}
