using System;
using UnityEngine;

namespace UDBase.Controllers.AudioSystem {

	/// <summary>
	/// Audio channel inspector setup
	/// </summary>
	[Serializable]
	public class ChannelSettings {

		/// <summary>
		/// Current volume parameter in given context
		/// </summary>
		public string ChannelParam {
			get {
				if ( _defaultSound ) {
					return Audio.DefaultSoundChannelVolume;
				}
				if ( _defaultMusic ) {
					return Audio.DefaultMusicChannelName;
				}
				return _channelParam;
			}
		}

		/// <summary>
		/// Current channel name in given context
		/// </summary>
		public string ChannelName {
			get {
				if ( _defaultSound ) {
					return Audio.DefaultSoundChannelName;
				}
				if ( _defaultMusic ) {
					return Audio.DefaultMusicChannelName;
				}
				return _channelName;
			}
		}

		[SerializeField]
		[Tooltip("Volume parameter to use")]
		string _channelParam = null;
		[SerializeField]
		[Tooltip("Channel name to use")]
		string _channelName = null;
		[SerializeField]
		[Tooltip("Use default sound channelName/param?")]
		bool _defaultSound = false;
		[SerializeField]
		[Tooltip("Use default music channelName/param?")]
		bool _defaultMusic = false;
	}
}
