using UnityEngine;
using System.Collections;

namespace UDBase.Common {
	public class Startup {
		
		// Using this method template logics can be loaded on first scene load
		// And before any Awake/OnEnable/Start methods are invoked
		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		static void OnApplicationStart() {
			Debug.Log("On Application Start");
		}
	}
}
