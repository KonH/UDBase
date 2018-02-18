using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UDBase.Controllers.UserSystem.UI {
	/// <summary>
	/// Display IUser.Name on UnityEngine.UI.Text component
	/// </summary>
	[AddComponentMenu("UDBase/UI/User/UserNameText")]
	[RequireComponent(typeof(Text))]
	public class UserNameText : MonoBehaviour {
		Text _text;

		IUser  _user;
		IEvent _events;

		[Inject]
		public void Init(IUser user, IEvent events) {
			_user   = user;
			_events = events;
		}

		void Start() {
			_text = GetComponent<Text>();
			UpdateValue(_user.Name);
			_events.Subscribe<User_NameChange>(this, OnUserNameChange);
		}

		void OnDestroy() {
			_events.Unsubscribe<User_NameChange>(OnUserNameChange);
		}

		void OnUserNameChange(User_NameChange e) {
			UpdateValue(e.Name);
		}

		void UpdateValue(string value) {
			_text.text = TextUtils.EnsureString(value);
		}
	}
}
