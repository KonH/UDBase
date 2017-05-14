namespace UDBase.Controllers.UserSystem {
	public class User : ControllerHelper<IUser> {

		public static string Id {
			get {
				if ( Instance != null ) {
					return Instance.Id;
				}
				return null;
			}
			set {
				if ( Instance != null ) {
					Instance.Id = value;
				}
			}
		}

		public static string Name {
			get {
				if ( Instance != null ) {
					return Instance.Name;
				}
				return null;
			}
			set {
				if ( Instance != null ) {
					Instance.Name = value;
				}
			}
		}

		public static string FindExternalId(string provider) {
			if ( Instance != null ) {
				return Instance.FindExternalId(provider);
			}
			return null;
		}
		public static void AddExternalId(string provider, string id) {
			if ( Instance != null ) {
				Instance.AddExternalId(provider, id);
			}
		}
	}
}
