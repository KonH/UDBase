using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;

namespace UDBase.Controllers.UserSystem {
	public class SaveUser : IUser {
		UserSaveNode _userNode;

		public string Id {
			get {
				return _userNode.Id;
			}
			set {
				if (value == _userNode.Id) {
					return;
				}
				_userNode.Id = value;
				UpdateNode();
			}
		}

		public string Name {
			get {
				return _userNode.Name;
			}
			set {
				if (value == _userNode.Name) {
					return;
				}
				_userNode.Name = value;
				UpdateNode();
			}
		}

		public SaveUser() {
			_userNode = LoadNode();
		}

		public string FindExternalId(string provider) {
			string value = null;
			if ( _userNode.ExternalIds != null ) {
				_userNode.ExternalIds.TryGetValue(provider, out value);
			}
			return value;
		}

		public void AddExternalId(string provider, string id) {
			if ( _userNode.ExternalIds == null ) {
				_userNode.ExternalIds = new Dictionary<string, string>();
			}
			var ids = _userNode.ExternalIds;
			if ( ids.ContainsKey(provider) ) {
				ids[provider] = id;
			} else {
				ids.Add(provider, id);
			}
			UpdateNode();
		}

		UserSaveNode LoadNode() {
			return Save.GetNode<UserSaveNode>();
		}

		void UpdateNode() {
			Save.SaveNode(_userNode);
		}
	}
}
