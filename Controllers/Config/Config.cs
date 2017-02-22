﻿using System.Collections.Generic;

namespace UDBase.Controllers.ConfigSystem {
	public sealed class Config : ControllerHelper<IConfig> {
		
		public static T GetNode<T>() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return default(T);
		}

		public static T GetItem<T>(string name) {
			if( Instance != null ) {
				return Instance.GetItem<T>(name);
			}
			return default(T);
		}

		public static Dictionary<string, T> GetItems<T>() {
			if ( Instance != null ) {
				return Instance.GetItems<T>();
			}
			return null;
		}
	}
}
