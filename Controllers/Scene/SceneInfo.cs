using System.Text;

namespace UDBase.Controllers.SceneSystem {
	/*
	 * Basic scene info - requires only name
	 */
	public struct SceneName : ISceneInfo {
		public string Name { get; private set; }

		public SceneName(string name) {
			Name = name;
		}
	}

	/*
	 * Specific info - custom type and (optional) parameter
	 */
	public struct SceneParam<T> : ISceneInfo {
		public string Type  { get; private set; }
		public string Param { get; private set; }
		public string Name  { get; private set; }

		public SceneParam(T type, string param) {
			Type  = type.ToString();
			Param = param;
			if( string.IsNullOrEmpty(param) ) {
				Name = Type;
			} else {
				Name = string.Format("{0}_{1}", type, param);
			}
		}
	}

	/*
	 * And much more specific info - custom type and > 1 parameter
	 */
	public struct MultiSceneParam<T> : ISceneInfo {
		public string   Type   { get; private set; }
		public string[] Params { get; private set; }
		public string   Name   { get; private set; }

		public MultiSceneParam(T type, params string[] param) {
			Type = type.ToString();
			Params = param;
			var sb = new StringBuilder();
			sb.Append(type);
			for( int i = 0; i < param.Length; i++ ) {
				sb.Append("_");
				sb.Append(param[i]);
			}
			Name = sb.ToString();
		}
	}
}