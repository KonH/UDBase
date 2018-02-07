namespace UDBase.Controllers.AudioSystem {
	public struct VolumeChangeEvent {

		public string Channel { get; private set; }
		public float  Volume  { get; private set; }

		public VolumeChangeEvent(string channel, float volume) {
			Channel = channel;
			Volume  = volume;
		}
	}
}
