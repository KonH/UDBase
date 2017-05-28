namespace UDBase.Controllers.AudioSystem {
	public interface IAudio : IController {
		void MuteChannel  (string parameter);
		void UnMuteChannel(string parameter);
		void ToggleChannel(string parameter);
	}
}