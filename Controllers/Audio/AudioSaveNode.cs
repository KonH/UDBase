using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using FullSerializer;

namespace UDBase.Controllers.AudioSystem {
	public class AudioSaveNode:ISaveSource {
		[fsProperty("channels")]
		public Dictionary<string, ChannelNode> Channels { get; set; }
	}

	public class ChannelNode {
		[fsProperty("vol")]
		public float Volume { get; set; }
		[fsProperty("mute")]
		public bool IsMuted { get; set; }
	}
}
