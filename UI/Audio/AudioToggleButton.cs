using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;

namespace UDBase.Controllers.AudioSystem.UI {
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {

		public GameObject ActiveItem  = null;
		public GameObject MutedItem   = null;
		public string    ChannelName  = null;
		public bool      DefaultSound = false;
		public bool      DefaultMusic = false;

		Button _button = null;

		void OnEnable() {
			Events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			Events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
			SetupChannelName();
			UpdateState();
		}

		void SetupChannelName() {
			if ( DefaultSound ) {
				ChannelName = Audio.Default_Sound_Channel_Volume;
			}
			if ( DefaultMusic ) {
				ChannelName = Audio.Default_Music_Channel_Volume;
			}
		}

		void UpdateState() {
			var muted = Audio.IsChannelMuted(ChannelName);
			if ( ActiveItem ) {
				ActiveItem.SetActive(!muted);
			}
			if ( MutedItem ) {
				MutedItem.SetActive(muted);
			}
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == ChannelName ) {
				UpdateState();
			}
		}

		void OnClick() {
			Audio.ToggleChannel(ChannelName);
		}
	}
}
