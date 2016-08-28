using UnityEngine;
using System.Collections;
using UDBase.Components;

namespace UDBase.Components.Config {
	public class Config : ComponentHelper<IConfig> {

		public static T GetNode<T>() where T:class, IConfigNode, new() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return null;
		}
	}
}
