using UnityEngine;
using System.Collections;

namespace UDBase.Components.Scene {
	public class Scene : ComponentHelper<IScene> {

		public static void LoadScene(string sceneName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].LoadScene(sceneName);
			}
		}
	}
}
