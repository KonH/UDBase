using System;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.ContentSystem {
	public static class Content {
		public static string GetTypeString(Type type) {
			return type.FullName;
		}

		public static string GetAssetType(Object asset) {
			return GetTypeString(asset.GetType());
		}

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
