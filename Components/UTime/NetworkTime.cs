using UnityEngine;
using System;
using System.Collections;
using UDBase.Utils;

namespace UDBase.Components.UTime {
	public class NetworkTime : ITime {

		public void Init () {
			var helper = ResourcesLoader.CreatePersistant<NetworkTimeHelper>();
			if( helper != null ) {
				helper.Execute(GetTimeRequest());
			}
		}

		IEnumerator GetTimeRequest() {
			var request = new WWW("http://www.timeapi.org/utc/now");
			yield return request;
			Debug.Log("Net request result: " + request.text);
			var time = DateTime.Parse(request.text);
			Debug.Log("Parsed time: " + time.ToUniversalTime());
			Debug.Log("Device time: " + DateTime.UtcNow);
		}

		// Update is called once per frame
		void Update () {
		
		}

		public bool IsAvailable
		{
			get
			{
				// TODO
				return false;
			}
		}

		public bool IsFailed
		{
			get
			{
				// TODO
				return true;
			}
		}

		public DateTime CurrentTime
		{
			get
			{
				// TODO
				return DateTime.Now;
			}
		}
	}
}
