using System;
using FullSerializer;

namespace UDBase.Controllers.SaveSystem {
	public class SaveInfoNode:ISaveSource {
		[fsProperty("ver")]
		public long   Version   { get; private set; }
		[fsProperty("time")]
		public long   LocalTime { get; private set; }

		public void Update() {
			Version++;
			LocalTime = DateTime.Now.ToFileTime();
		}
	}
}