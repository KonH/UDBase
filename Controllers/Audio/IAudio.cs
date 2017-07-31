namespace UDBase.Controllers.AudioSystem {
	public interface IAudio : IController {
		void  MuteChannel     (string parameter);
		void  UnMuteChannel   (string parameter);
		float GetChannelVolume(string parameter);
		bool  IsChannelMuted  (string parameter);
		void  ToggleChannel   (string parameter);
		void  SetChannelVolume(string parameter, float normalizedVolume);
	}
}