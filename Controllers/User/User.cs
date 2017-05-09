
namespace UDBase.Controllers.UserSystem {
	public class User : ControllerHelper<IUser> {

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
	}
}
