using UnityEngine;
using System;
using System.Collections;
using UDBase.Utils;

namespace UDBase.Controllers.UTime {
	public class NetworkTime : ITime {

		public void Init () {
			var helper = UnityHelper.AddPersistant<NetworkTimeHelper>();
			if( helper != null ) {
				helper.Execute(GetTimeRequest());
			}
		}

		public void PostInit() {}

		IEnumerator GetTimeRequest() {
			var request = new WWW("http://104.236.100.182:8080/time");
			yield return request;
			Debug.Log("Net request result: " + request.text);
			var time = DateTime.Parse(request.text);
			Debug.Log("Parsed time: " + time.ToUniversalTime());
			Debug.Log("Device time: " + DateTime.UtcNow);
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
