using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.ContentSystem {

	/// <summary>
	/// Set of content for Content Loaders in project
	/// </summary>
	public class ContentConfig : ScriptableObject {

		/// <summary>
		/// All items in config
		/// </summary>
		public List<ContentId> Items = new List<ContentId>();
	}
}
