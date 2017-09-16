using System;

namespace UDBase.Controllers.AudioSystem {
	[Serializable]
	public class ChannelSettings {
		public string ChannelParam;
		public string ChannelName;
		public bool   DefaultSound = false;
		public bool   DefaultMusic = false;

		public void SetupChannelParams() {
			if ( DefaultSound ) {
				ChannelParam = Audio.DefaultSoundChannelVolume;
				ChannelName  = Audio.DefaultSoundChannelName;
			}
			if ( DefaultMusic ) {
				ChannelParam = Audio.DefaultMusicChannelVolume;
				ChannelName  = Audio.DefaultSoundChannelName;
			}
		}
	}
}
