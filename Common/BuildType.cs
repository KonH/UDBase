using UnityEngine;

namespace UDBase.Common {
    public class BuildType {
		public virtual string          Type     { get; }
		public virtual RuntimePlatform Platform { get; }
		public virtual bool            IsEditor { get; }

		public BuildType(string type, RuntimePlatform platform, bool isEditor) {
			Type     = type;
			Platform = platform;
			IsEditor = isEditor;
		}

		public bool Is(string buildType) {
			return Type == buildType;
		}

		public override string ToString() {
			return $"Type: '{Type}', Platform: '{Platform}', IsEditor: '{IsEditor}'";
		}
	}
}