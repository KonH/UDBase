using System;

namespace UDBase.Controllers.AudioSystem {
	[Serializable]
	public class ChannelSettings {
		public string ChannelName;
		public bool DefaultSound = false;
		public bool DefaultMusic = false;

		public void SetupChannelName() {
			if ( DefaultSound ) {
				ChannelName = Audio.DefaultSoundChannelVolume;
			}
			if ( DefaultMusic ) {
				ChannelName = Audio.DefaultMusicChannelVolume;
			}
		}
	}
}
