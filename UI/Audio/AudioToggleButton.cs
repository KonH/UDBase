using UnityEngine;
using UnityEngine.UI;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {

		public string VolumeParameter  = null;
		public bool   DefaultSound     = false;
		public bool   DefaultMusic     = false;

		Button _button = null;

		void Awake() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
			SetupChannelName();
		}

		void SetupChannelName() {
			if ( DefaultSound ) {
				VolumeParameter = Audio.Default_Sound_Channel_Volume;
			}
			if ( DefaultMusic ) {
				VolumeParameter = Audio.Default_Music_Channel_Volume;
			}
		}

		void OnClick() {
			Audio.ToggleChannel(VolumeParameter);
		}
	}
}
