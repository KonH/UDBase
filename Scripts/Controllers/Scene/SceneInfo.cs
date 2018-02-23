using System.Text;

namespace UDBase.Controllers.SceneSystem {

	/// <summary>
	/// Scene info factory
	/// </summary>
	public static class SceneInfo {
		public static ISceneInfo Get<T>(T type) {
			return new SceneParam<T>(type, "");
		}

		public static ISceneInfo Get<T>(T type, string param) {
			return new SceneParam<T>(type, param);
		}

		public static ISceneInfo Get<T>(T type, params string[] param) {
			return new MultiSceneParam<T>(type, param);
		}
	}

	/// <summary>
	/// Basic scene info - requires only name.
	/// Example: MainMenu, Settings, etc.
	/// </summary>
	public struct SceneName : ISceneInfo {
		public string Name { get; private set; }

		public SceneName(string name) {
			Name = name;
		}

		public override string ToString() {
			return Name;
		}
	}

	/// <summary>
	/// Specific info - custom type and (optional) parameter.
	/// Example: Level_1, Level_N, etc.
	/// </summary>
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

	/// <summary>
	/// Multi scene parameter - custom type with >1 parameters.
	/// Example: Level_Type1_1, Level_TypeN_N, etc.
	/// </summary>
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