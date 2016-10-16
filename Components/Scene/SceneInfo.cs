using UnityEngine;
using System.Collections;
using System.Text;

namespace UDBase.Components.Scene {
	/*
	 * Basic scene info - requires only name
	 */
	public struct SceneName : ISceneInfo {
		string _name;
		public string Name { get { return _name; } }

		public SceneName(string name) {
			_name = name;
		}
	}

	/*
	 * Specific info - custom type and (optional) parameter
	 */
	public struct SceneParam<T> : ISceneInfo {
		string _name;
		public string Name { get { return _name; } }

		public SceneParam(T type, string param) {
			if( string.IsNullOrEmpty(param) ) {
				_name = type.ToString();
			} else {
				_name = string.Format("{0}_{1}", type, param);
			}
		}
	}

	/*
	 * And much more specific info - custom type and > 1 parameter
	 */
	public struct MultiSceneParam<T> : ISceneInfo {
		string _name;
		public string Name { get { return _name; } }

		public MultiSceneParam(T type, params string[] param) {
			var sb = new StringBuilder();
			sb.Append(type);
			for( int i = 0; i < param.Length; i++ ) {
				sb.Append("_");
				sb.Append(param[i]);
			}
			_name = sb.ToString();
		}
	}
}