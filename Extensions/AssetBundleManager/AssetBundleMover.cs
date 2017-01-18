using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.IO;

namespace AssetBundles
{
	public static class AssetBundleMover 
	{
		public static void TryToMoveAssetBundles() 
		{
			string inputPath = Path.Combine(Utility.AssetBundlesOutputPath, Utility.GetPlatformName());
			if( Directory.Exists(inputPath) ) 
			{
				string streamingPath = Path.Combine("Assets", "StreamingAssets");
				if( Directory.Exists(streamingPath) ) 
				{
					Debug.LogWarningFormat("Directory '{0}' exist, clean it.", streamingPath);
					Directory.Delete(streamingPath);
				}
				Directory.Move(inputPath, streamingPath);
				#if UNITY_EDITOR
				AssetDatabase.Refresh();
				#endif
				Debug.LogFormat("AssetBundles from '{0}' moved to '{1}'", inputPath, streamingPath);
			} 
			else 
			{
				Debug.LogErrorFormat("AssetBundles not found at '{0}'", inputPath);
			}
		}
	}
}
