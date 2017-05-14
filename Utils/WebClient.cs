using System;
using System.Collections.Generic;

namespace UDBase.Utils {
	public class WebClient {

		const string AuthHeaderName = "Authorization";

		string                     _authHeaderValue = null;
		Dictionary<string, string> _authHeaderOnly  = null;

		public WebClient(string userName, string userPassword) {
			_authHeaderValue = NetUtils.CreateBasicAuthorization(userName, userPassword);
			_authHeaderOnly = UpdateHeaders(new Dictionary<string, string>());
		}

		Dictionary<string, string> UpdateHeaders(Dictionary<string, string> originalHeaders) {
			if ( originalHeaders == null ) {
				return _authHeaderOnly;
			} else {
				originalHeaders.Add(AuthHeaderName, _authHeaderValue);
				return originalHeaders;
			}
		}

		public void SendGetRequest(
			string url,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null)
		{
			headers = UpdateHeaders(headers);
			NetUtils.SendGetRequest(url, timeout, headers, onComplete);
		}

		public void SendPostRequest(
			string url,
			string data,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null)
		{
			headers = UpdateHeaders(headers);
			NetUtils.SendPostRequest(url, data, timeout, headers, onComplete);
		}
	}
}
