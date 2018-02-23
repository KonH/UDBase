using UnityEngine;

namespace UDBase.Common {
	/// <summary>
	/// Information defining the execution context for further use in conditial binding
	/// </summary>
	public class BuildType {
		/// <summary>
		/// What build type is it? (e.g. "DEV", "PROD" etc.)
		/// </summary>
		public virtual string Type { get; }
		
		/// <summary>
		/// Equals to Application.platform, but can be overriden
		/// </summary>
		public virtual RuntimePlatform Platform { get; }

		/// <summary>
		/// Equals to Application.isEditor, but can be overriden
		/// </summary>
		public virtual bool IsEditor { get; }

		public BuildType(string type, RuntimePlatform platform, bool isEditor) {
			Type     = type;
			Platform = platform;
			IsEditor = isEditor;
		}

		/// <summary>
		/// Return true, if it is given buildType
		/// </summary>
		public bool Is(string buildType) {
			return Type == buildType;
		}

		public override string ToString() {
			return $"Type: '{Type}', Platform: '{Platform}', IsEditor: '{IsEditor}'";
		}
	}
}