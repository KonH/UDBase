using UDBase.Controllers.EventSystem;
using UDBase.Utils;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UDBase.Controllers.UserSystem.UI {
	[RequireComponent(typeof(Text))]
	public class UserNameText : MonoBehaviour {
		Text _text;

		IUser _user;

		[Inject]
		void Init(IUser user) {
			_user = user;
		}

		void Start() {
			_text = GetComponent<Text>();
			UpdateValue(_user.Name);
			Events.Subscribe<User_NameChange>(this, OnUserNameChange);
		}

		void OnDestroy() {
			Events.Unsubscribe<User_NameChange>(OnUserNameChange);
		}

		void OnUserNameChange(User_NameChange e) {
			UpdateValue(e.Name);
		}

		void UpdateValue(string value) {
			_text.text = TextUtils.EnsureString(value);
		}
	}
}
