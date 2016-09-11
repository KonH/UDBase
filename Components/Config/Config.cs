using UnityEngine;
using System.Collections;
using UDBase.Components;
using UDBase.Utils.Json;

namespace UDBase.Components.Config {
	public class Config : ComponentHelper<IConfig> {

		public static T GetNode<T>() where T:class, IJsonNode, new() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return null;
		}
	}
}
