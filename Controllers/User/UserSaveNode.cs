using FullSerializer;

namespace UDBase.Controllers.UserSystem {
	public class UserSaveNode {
		
		[fsProperty("name")]
		public string Name { get; set; }
	}
}
