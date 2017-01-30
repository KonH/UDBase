using UnityEngine;
using System;
using System.Collections;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.UTime {
	public class NetworkTime : ITime {

		string   _url          = null;
		float    _timeout      = 0.0f;
		DateTime _startDate    = default(DateTime);
		float    _requestStart = 0;
		float    _startTime    = 0;

		public NetworkTime(string url, float timeout = 10.0f, bool isTrusted = true) {
			_url      = url;
			_timeout  = timeout;
			IsTrusted = isTrusted;
		}

		public void Init () {
			var helper = UnityHelper.AddPersistant<NetworkTimeHelper>();
			if( helper != null ) {
				helper.Execute(GetTimeRequest());
			}
		}

		public void PostInit() {}

		float GetAppTime() {
			return Time.realtimeSinceStartup;
		}

		IEnumerator GetTimeRequest() {
			Log.MessageFormat("Start load from '{0}'", LogTags.Time, _url);
			var request = new WWW(_url);
			_requestStart = GetAppTime();
			while( !request.isDone ) {
				if( GetAppTime() - _requestStart > _timeout ) {
					break;
				}
				yield return null;
			}
			if ( request.isDone ) {
				if( request.error == null ) {
					var dt = default(DateTime);
					if( DateTime.TryParse(request.text, out dt) ) {
						_startDate = dt.ToUniversalTime();
						_startTime = GetAppTime();
						Log.MessageFormat("NetworkTime: {0}", LogTags.Time, _startDate);
						IsAvailable = true;
					} else {
						Log.ErrorFormat("Parsing error: '{0}' to DateTime", LogTags.Time, dt);
						IsFailed = true;
					}
				} else {
					Log.ErrorFormat("Request error: {0}", LogTags.Time, request.error);
					IsFailed = true;
				}
			} else {
				Log.Error("Request timeout", LogTags.Time);
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
