using System;
using FullSerializer;

namespace UDBase.Controllers.SaveSystem {

	/// <summary>
	/// Save node with information about save itself
	/// </summary>
	public class SaveInfoNode:ISaveSource {

		/// <summary>
		/// How many times save have been saved
		/// </summary>
		[fsProperty("ver")]
		public long Version { get; private set; }

		/// <summary>
		/// Last saved local date time
		/// </summary>
		[fsProperty("time")]
		public long LocalTime { get; private set; }

		internal void Update() {
			Version++;
			LocalTime = DateTime.Now.ToFileTime();
		}
	}
}