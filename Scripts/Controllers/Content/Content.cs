using System;
using System.Collections.Generic;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Helper methods for IContent
	/// </summary>
	public static class Content {

		/// <summary>
		/// Convert type instance to string
		/// </summary>
		public static string GetTypeString(Type type) {
			return type.FullName;
		}

		/// <summary>
		/// Convert type of given asset to string
		/// </summary>
		public static string GetAssetType(Object asset) {
			return GetTypeString(asset.GetType());
		}

		/// <summary>
		/// Gets the loader for given ContentId loading type 
		/// </summary>
		public static IContent GetLoaderFor(this List<IContent> loaders, ContentId contentId) {
			foreach ( var loader in loaders ) {
				if ( loader.CanLoad(contentId) ) {
					return loader;
				}
			}
			return null;
		}
	}
}
