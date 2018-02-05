using System;
using UnityEngine;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.UTime {
	public class NetworkTime : ITime {

		[Serializable]
		public class Settings {
			public string Url;
			public float Timeout;
		}

		readonly string _url;
		readonly float  _timeout;
		
		DateTime _startDate = default(DateTime);
		float    _startTime;

		NetUtils _net;
		ILog _log;

		public NetworkTime(Settings settings, NetUtils net, ILog log) {
			_url      = settings.Url;
			_timeout  = settings.Timeout;
			_net = net;
			_log = log;
			_net.SendGetRequest(_url, timeout: _timeout, onComplete: OnTimeRequestComplete);
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
					_log.MessageFormat(LogTags.Time, "NetworkTime: {0}", _startDate);
					IsAvailable = true;
				} else {
					_log.ErrorFormat(LogTags.Time, "Parsing error: '{0}' to DateTime", dt);
					IsFailed = true;
				}
			} else {
				if( response.HasError ) {
					_log.ErrorFormat(LogTags.Time, "Request error: {0}", response.Error);
				} else if( response.Timeout ) {
					_log.Error(LogTags.Time, "Request timeout");
				} else {
					_log.Error(LogTags.Time, "Request unknown error");
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
