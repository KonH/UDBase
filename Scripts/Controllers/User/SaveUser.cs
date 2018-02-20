using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;

namespace UDBase.Controllers.UserSystem {

	/// <summary>
	/// User controller with saving information using ISave
	/// </summary>
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

		ISave _save;

		public SaveUser(ISave save) {
			_save = save;
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
			return _save.GetNode<UserSaveNode>();
		}

		void UpdateNode() {
			_save.SaveNode(_userNode);
		}
	}
}
