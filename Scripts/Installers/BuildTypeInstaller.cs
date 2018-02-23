using UnityEngine;
using UDBase.Common;
using Zenject;

namespace UDBase.Installers {
	/// <summary>
	/// Scriptable object UDBase installer for load BuildType from given source before all installers is called 
	/// </summary>
	[CreateAssetMenu(fileName = "BuildType", menuName = "UDBase/BuildTypeSettings")]
	public class BuildTypeInstaller : ScriptableObjectInstaller {

		/// <summary>
		/// Build type loading type
		/// </summary>
		public enum BuildTypeSource {

			/// <summary>
			/// Directly from settings asset
			/// </summary>
			FromSettings,

			/// <summary>
			/// From resources text file
			/// </summary>
			FromResources
		}

		/// <summary>
		/// Current build type if Source = FromSettings
		/// </summary>
		[Tooltip("Current build type if Source = FromSettings")]
		public string Type;

		/// <summary>
		/// Where is your build type?
		/// </summary>
		[Tooltip("Where is your build type?")]
		public BuildTypeSource Source;

		/// <summary>
		/// What file is used in resources if Source = FromResources
		/// </summary>
		[Tooltip("What file is used in resources if Source = FromResources")]
		public string FileName;

		/// <summary>
		/// Use overriden values in editor
		/// </summary>
		[Header("Editor Override")]
		[Tooltip("Use overriden values in editor")]
		public bool UseOverrides;

		/// <summary>
		/// Overriden type in editor
		/// </summary>
		[Tooltip("Overriden type in editor")]
		public string OverrideType;

		/// <summary>
		/// Overriden platform in editor
		/// </summary>
		[Tooltip("Overriden platform in editor")]
		public RuntimePlatform OverridePlatform;

		/// <summary>
		/// Overriden 'in editor' value in editor
		/// </summary>
		[Tooltip("Overriden 'in editor' value in editor")]
		public bool OverrideIsEditor;

		/// <summary>
		/// Creates and bind current build type
		/// </summary>
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