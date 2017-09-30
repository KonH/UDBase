using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.AudioSystem;

namespace UDBase.Controllers.SoundSystem {
	public class Sound : ControllerHelper<SoundController> {
		public static void Play(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName) {
			if ( Instance != null ) {
				Instance.Play(sound, delay, channelName);
			}
		}

		public static void StartLoop(ContentId sound, float delay = 0, string channelName = Audio.DefaultSoundChannelName) {
			if ( Instance != null ) {
				Instance.StartLoop(sound, delay, channelName);
			}
		}

		public static void EndLoop(ContentId sound) {
			if ( Instance != null ) {
				Instance.EndLoop(sound);
			}
		}
	}
}
