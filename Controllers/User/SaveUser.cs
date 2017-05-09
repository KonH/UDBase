using UDBase.Controllers.SaveSystem;

namespace UDBase.Controllers.UserSystem {
	public class SaveUser : IUser {

		public void Init() {}

		public void PostInit() {
			_userNode = LoadNode();
		}

		public void Reset() {}

		public string Name {
			get {
				return _userNode.Name;
			}
			set {
				if ( value != _userNode.Name ) {
					_userNode.Name = value;
					UpdateNode();
				}
			}
		}
		
		UserSaveNode _userNode = null;

		UserSaveNode LoadNode() {
			return Save.GetNode<UserSaveNode>();
		}

		void UpdateNode() {
			Save.SaveNode(_userNode);
		}
	}
}
