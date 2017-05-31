using System;

namespace UDBase.Controllers.AudioSystem {
	[Serializable]
	public class ChannelSettings {

		public string ChannelName = null;
		public bool DefaultSound = false;
		public bool DefaultMusic = false;

		public void SetupChannelName() {
			if ( DefaultSound ) {
				ChannelName = Audio.Default_Sound_Channel_Volume;
			}
			if ( DefaultMusic ) {
				ChannelName = Audio.Default_Music_Channel_Volume;
			}
		}
	}
}
