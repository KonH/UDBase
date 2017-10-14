using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.UserSystem {
	public class User : ControllerHelper<IUser> {
		public static string Id {
			get {
				return (Instance != null) ? Instance.Id : null;
			}
			set {
				if (Instance == null) {
					return;
				}
				Instance.Id = value;
			}
		}

		public static string Name {
			get {
				return (Instance != null) ? Instance.Name : null;
			}
			set {
				if ( Instance != null ) {
					Instance.Name = value;
					Events.Fire(new User_NameChange(value));
				}
			}
		}

		public static string FindExternalId(string provider) {
			return (Instance != null) ? Instance.FindExternalId(provider) : null;
		}
		public static void AddExternalId(string provider, string id) {
			if ( Instance != null ) {
				Instance.AddExternalId(provider, id);
				Events.Fire(new User_ExternalIdChange(provider, id));
			}
		}
	}
}
