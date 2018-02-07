namespace UDBase.Utils {
	public static class AssetUtils {		
		const string SceneExtension = ".unity";

		public static string ConvertScenePathToName(string path) {
			var parts = path.Split('/');
			if( parts.Length > 0 ) {
				var result = parts[parts.Length-1];
				var extLen = SceneExtension.Length;
				if( result.Length > extLen ) {
					result = result.Remove(result.Length - extLen, extLen);
					return result;
				}
			}
			return null;
		}
	}
}
