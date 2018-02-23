namespace UDBase.Controllers.AudioSystem {
	/// <summary>
	/// Event, which fired when volume of specific channel was changed
	/// </summary>
	public struct VolumeChangeEvent {

		public string Channel { get; private set; }
		public float  Volume  { get; private set; }

		public VolumeChangeEvent(string channel, float volume) {
			Channel = channel;
			Volume  = volume;
		}
	}
}
