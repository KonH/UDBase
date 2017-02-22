using UnityEngine;
using System;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.UTime {
	public class NetworkTime : ITime {

		string   _url          = null;
		float    _timeout      = 0.0f;
		DateTime _startDate    = default(DateTime);
		float    _startTime    = 0;

		public NetworkTime(string url, float timeout = 10.0f, bool isTrusted = true) {
			_url      = url;
			_timeout  = timeout;
			IsTrusted = isTrusted;
		}

		public void Init () {
			NetUtils.SendRequest(_url, _timeout, OnTimeRequestComplete);
		}

		public void PostInit() {}
		
		public void Reset() {}

		float GetAppTime() {
			return Time.realtimeSinceStartup;
		}

		void OnTimeRequestComplete(NetUtils.Response response) {
			if ( !response.IsEmpty ) {
				var dt = default(DateTime);
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

		public bool IsTrusted   { get; private set; }
		public bool IsAvailable { get; private set; }
		public bool IsFailed    { get; private set; }

		public DateTime CurrentTime
		{
			get
			{
				if( IsAvailable ) {
					return _startDate.AddSeconds((double)(GetAppTime() - _startTime));
				}
				return default(DateTime);
			}
		}
	}
}
