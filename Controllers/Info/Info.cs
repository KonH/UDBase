using UnityEngine;
using System.Collections;
using UDBase.Controllers;

namespace UDBase.Controllers.InfoSystem {
	public interface IInfoBase:IController {
		
	}

	public interface IInfo<T>:IInfoBase {
		T GetInfo(string name);
	}

	public class ConfigInfoHolder<T>:IInfo<T> where T:new() {
		public void Init() {}
		public void PostInit() {}

		public T GetInfo(string name) {
			var data = new T();
			return data;
		}
	}

	public class TestData {
		public string Name = "123";
		public int Data = 12345;
	}

	public class Info : ControllerHelper<IInfoBase> {

		public static T GetInfo<T>(string name) {
			for( int i = 0; i < Instances.Count; i++) {
				var instance = Instances[i] as IInfo<T>;
				if( instance != null ) {
					return instance.GetInfo(name);
				}
			}
			return default(T);
		}
	}
}
