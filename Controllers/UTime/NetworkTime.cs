using System;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.UTime {
	public class NetworkTime : ITime {
		readonly string _url;
		readonly float  _timeout;
		
		DateTime _startDate = default(DateTime);
		float    _startTime;

		public NetworkTime(string url, float timeout = 10.0f) {
			_url      = url;
			_timeout  = timeout;
			NetUtils.SendGetRequest(_url, timeout: _timeout, onComplete: OnTimeRequestComplete);
		}

		float GetAppTime() {
			return Time.realtimeSinceStartup;
		}

		void OnTimeRequestComplete(NetUtils.Response response) {
			if ( !response.IsEmpty ) {
				DateTime dt;
				if( DateTime.TryParse(response.Text, out dt) ) {
					_startDate = dt.ToUniversalTime();
					_startTime = GetAppTime();
					Log.MessageFormat("NetworkTime: {0}", LogTags.Time, _startDate);
					IsAvailable = true;
				} else {
					Log.ErrorFormat("Parsing error: '{0}' to DateTime", LogTags.Time, dt);
					IsFailed = true;
				}
			} else {
				if( response.HasError ) {
					Log.ErrorFormat("Request error: {0}", LogTags.Time, response.Error);
				} else if( response.Timeout ) {
					Log.Error("Request timeout", LogTags.Time);
				} else {
					Log.Error("Request unknown error", LogTags.Time);
				}
				IsFailed = true;
			}
		}

		public bool IsAvailable { get; private set; }
		public bool IsFailed    { get; private set; }

		public DateTime CurrentTime
		{
			get {
				return IsAvailable ? 
					_startDate.AddSeconds(GetAppTime() - _startTime) : 
					default(DateTime);
			}
		}
	}
}
