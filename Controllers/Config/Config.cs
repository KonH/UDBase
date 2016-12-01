using UnityEngine;
using System.Collections;
using UDBase.Controllers;
using UDBase.Utils.Json;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class Config : ControllerHelper<IConfig> {
		
		public static T GetNode<T>() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return default(T);
		}
	}
}
