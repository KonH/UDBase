using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FullSerializer;

namespace UDBase.Controllers.SaveSystem {
	public class SaveInfoNode {

		[fsProperty("ver")]
		public long   Version   { get; private set; }
		[fsProperty("time")]
		public long   LocalTime { get; private set; }

		public SaveInfoNode() {}

		public void Update() {
			Version++;
			LocalTime = DateTime.Now.ToFileTime();
			Debug.Log(long.MaxValue);
		}
	}
}