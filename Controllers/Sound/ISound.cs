using UDBase.Controllers.ContentSystem;

namespace UDBase.Controllers.SoundSystem {
	public interface ISound : IController {
		void Play(ContentId sound, float delay, string channelName);
		void StartLoop(ContentId sound, float delay, string channelName);
		void EndLoop(ContentId sound);
	}
}