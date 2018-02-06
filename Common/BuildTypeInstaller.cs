using UnityEngine;
using Zenject;

namespace UDBase.Common {
	[CreateAssetMenu(fileName = "BuildType", menuName = "UDBase/BuildTypeSettings")]
	public class BuildTypeInstaller : ScriptableObjectInstaller {
		public enum BuildTypeSource {
			FromSettings,
			FromResources
		}

		public string          Type;
		public BuildTypeSource Source;
		public string          FileName;

		[Header("Editor Override")]
		public bool            UseOverrides;
		public string          OverrideType;
		public RuntimePlatform OverridePlatform;
		public bool            OverrideIsEditor;

		public override void InstallBindings() {
			BuildType buildType;
			if ( Application.isEditor && UseOverrides ) {
				buildType = GetOverridedBuildType();
			} else {
				buildType = GetRuntimeBuildType(Source, FileName);
			}
			Container.BindInstance(buildType);
		}

		BuildType GetOverridedBuildType() {
			return new BuildType(OverrideType, OverridePlatform, OverrideIsEditor);
		}

		BuildType CreateRuntimeBuildType(string type) {
			return new BuildType(type, Application.platform, Application.isEditor);
		}

		BuildType GetRuntimeBuildType(BuildTypeSource source, string fileName) {
			switch ( source ) {
				case BuildTypeSource.FromSettings       : return CreateRuntimeBuildType(Type);
				case BuildTypeSource.FromResources      : return GetBuildTypeFromResources(fileName);
				default                                 : return null;
			}
		}

		BuildType GetBuildTypeFromResources(string fileName) {
			var asset = Resources.Load<TextAsset>(fileName);
			if ( asset ) {
				var type = asset.text.Trim();
				return CreateRuntimeBuildType(type);
			}
			return null;
		}
	}
}