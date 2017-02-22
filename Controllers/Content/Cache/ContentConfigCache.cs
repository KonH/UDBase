using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentConfigCache : ScriptableObject {

		public List<ContentDescription> Items = new List<ContentDescription>();

		public ContentDescription Add(ContentId contentId, Object asset = null) {
			var description = new ContentDescription();
			description.Id = contentId;
			description.Asset = asset;
			Items.Add(description);
			return description;
		}

		public ContentDescription GetOrCreate(ContentId contentId) {
			for( int i = 0; i < Items.Count; i++) {
				var item = Items[i];
				if( item.Id == contentId ) {
					return item;
				}
			}
			return Add(contentId);
		}

		public void Remove(ContentId contentId) {
			for( int i = 0; i < Items.Count; i++ ) {
				var item = Items[i];
				if( item.Id == contentId ) {
					Items.RemoveAt(i);
					i--;
				}
			}
		}
	}
}
