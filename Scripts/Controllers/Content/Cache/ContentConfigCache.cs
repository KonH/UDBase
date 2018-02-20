using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Content setup cache
	/// </summary>
	public class ContentConfigCache : ScriptableObject {

		public List<ContentDescription> Items = new List<ContentDescription>();

		public ContentDescription Add(ContentId contentId, Object asset = null) {
			var description = new ContentDescription {
				Id = contentId,
				Asset = asset
			};
			Items.Add(description);
			return description;
		}

		public ContentDescription GetOrCreate(ContentId contentId) {
			for ( var i = 0; i < Items.Count; i++) {
				var item = Items[i];
				if( item.Id == contentId ) {
					return item;
				}
			}
			return Add(contentId);
		}

		public void Remove(ContentId contentId) {
			for ( var i = 0; i < Items.Count; i++ ) {
				var item = Items[i];
				if (item.Id != contentId) {
					continue;
				}
				Items.RemoveAt(i);
				i--;
			}
		}
	}
}
