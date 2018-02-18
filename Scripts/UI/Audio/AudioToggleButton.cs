using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.AudioSystem.UI {
	/// <summary>
	/// Button to mute/unmute IAudio channel
	/// </summary>
	[AddComponentMenu("UDBase/UI/AudioToggleButton")]
	[RequireComponent(typeof(Button))]
	public class AudioToggleButton : MonoBehaviour {
		public ChannelSettings Settings   = new ChannelSettings();
		public GameObject      ActiveItem;
		public GameObject      MutedItem;

		Button _button;

		IAudio _audio;
		IEvent _events;

		[Inject]
		public void Init(IAudio audio, IEvent events) {
			_audio  = audio;
			_events = events;
		}

		void OnEnable() {
			_events.Subscribe<VolumeChangeEvent>(this, OnVolumeChanged);
		}

		void OnDisable() {
			_events.Unsubscribe<VolumeChangeEvent>(OnVolumeChanged);
		}

		void Start() {
			_button = GetComponent<Button>();
			_button.onClick.AddListener(OnClick);
			UpdateState();
		}

		void UpdateState() {
			var muted = _audio.IsChannelMuted(Settings.ChannelParam);
			if ( ActiveItem ) {
				ActiveItem.SetActive(!muted);
			}
			if ( MutedItem ) {
				MutedItem.SetActive(muted);
			}
		}

		void OnVolumeChanged(VolumeChangeEvent e) {
			if ( e.Channel == Settings.ChannelParam ) {
				UpdateState();
			}
		}

		void OnClick() {
			_audio.ToggleChannel(Settings.ChannelParam);
		}
	}
}
