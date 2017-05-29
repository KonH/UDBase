using UnityEngine;
using System;
using System.Collections.Generic;

namespace UDBase.Utils {
	public class UnityCallbackTracker : MonoBehaviour {

		public List<Action> StartCallbacks = new List<Action>();

		void Start() {
			for ( int i = 0; i < StartCallbacks.Count; i++ ) {
				var current = StartCallbacks[i];
				if ( current != null ) {
					current();
				}
			}
		}
	}
}
