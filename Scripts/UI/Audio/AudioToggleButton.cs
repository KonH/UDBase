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

		/// <summary>
		/// Channel which will be muted
		/// </summary>
		[Tooltip("Channel which will be muted")]
		public ChannelSettings Settings = new ChannelSettings();

		/// <summary>
		/// Item to activate when channel is unmuted
		/// </summary>
		[Tooltip("Item to activate when channel is unmuted")]
		public GameObject ActiveItem;

		/// <summary>
		/// Item to activate when channel is muted
		/// </summary>
		[Tooltip("Item to activate when channel is muted")]
		public GameObject MutedItem;

		Button _button;

		IAudio _audio;
		IEvent _events;

		/// <summary>
		/// Init with dependencies
		/// </summary>
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
