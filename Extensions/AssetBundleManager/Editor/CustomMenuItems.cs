using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AssetBundles
{
	public class CustomMenuItems
	{
		[MenuItem("Assets/AssetBundles/Move to StreamingAssets")]
		public static void MoveBundlesToStreamingAssets() 
		{
			AssetBundleMover.TryToMoveAssetBundles();
		}
	}
}
