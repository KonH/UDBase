using UnityEngine;
using System.Collections;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.ConfigSystem {
	public class Config : ControllerHelper<IConfig> {

		public static T GetNode<T>() where T:class, IJsonNode, new() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return null;
		}
	}
}
