using System.Collections.Generic;
using UDBase.Controllers.SaveSystem;
using FullSerializer;

namespace UDBase.Controllers.AudioSystem {

	/// <summary>
	/// Audio save node, used for save audio settings using SaveAudioController
	/// </summary>
	public class AudioSaveNode:ISaveSource {

		/// <summary>
		/// Gets or sets the controlled channel settings
		/// </summary>
		[fsProperty("channels")]
		public Dictionary<string, ChannelNode> Channels { get; set; }
	}

	/// <summary>
	/// Channel node.
	/// </summary>
	public class ChannelNode {

		/// <summary>
		/// Gets or sets the volume of this node
		/// </summary>
		[fsProperty("vol")]
		public float Volume { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this node is muted
		/// </summary>
		[fsProperty("mute")]
		public bool IsMuted { get; set; }
	}
}
