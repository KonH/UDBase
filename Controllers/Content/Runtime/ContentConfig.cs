using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {
	public class ContentConfig : ScriptableObject {
		public List<ContentId> Items = new List<ContentId>();

		public void Add(ContentId contentId) {
			Items.Add(contentId);
		}

		public void Remove(ContentId contentId) {
			Items.Remove(contentId);
		}
	}
}
