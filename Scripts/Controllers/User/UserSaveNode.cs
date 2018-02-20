using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using FullSerializer;

namespace UDBase.Controllers.UserSystem {

	/// <summary>
	/// Save node for user information
	/// </summary>
	public class UserSaveNode:ISaveSource {		
		[fsProperty("id")]
		public string Id { get; set; }

		[fsProperty("name")]
		public string Name { get; set; }

		[fsProperty("external_ids")]
		public Dictionary<string, string> ExternalIds { get; set; }
	}
}
