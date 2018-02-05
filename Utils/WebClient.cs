using System;
using System.Collections.Generic;

namespace UDBase.Utils {
	public class WebClient {

		const string AuthHeaderName = "Authorization";

		public bool InProgress {
			get {
				return _requestCount > 0;
			}
		}

		public bool HasAuthorization {
			get {
				return !string.IsNullOrEmpty(_authHeaderValue);
			}
		}

		string                     _authHeaderValue = null;
		Dictionary<string, string> _authHeaderOnly  = null;
		int                        _requestCount    = 0;

		NetUtils _net;

		public WebClient(NetUtils net) {
			_net = net;
			_authHeaderValue = "";
			_authHeaderOnly = new Dictionary<string, string>();
		}

		public WebClient(string userName, string userPassword) {
			_authHeaderValue = _net.CreateBasicAuthorization(userName, userPassword);
			_authHeaderOnly = UpdateHeaders(new Dictionary<string, string>());
		}

		Dictionary<string, string> UpdateHeaders(Dictionary<string, string> originalHeaders) {
			if ( originalHeaders == null ) {
				return _authHeaderOnly;
			} else {
				var newHeaders = new Dictionary<string, string>(originalHeaders);
				newHeaders.Add(AuthHeaderName, _authHeaderValue);
				return newHeaders;
			}
		}

		public void ApplyAuthHeader(string value) {
			_authHeaderValue = value;
			_authHeaderOnly = UpdateHeaders(new Dictionary<string, string>());
		}

		public void SendGetRequest(
			string url,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null)
		{
			_requestCount++;
			headers = UpdateHeaders(headers);
			_net.SendGetRequest(url, timeout, headers, resp => {
				_requestCount--;
				if ( onComplete != null ) {
					onComplete(resp);
				}
			});
		}

		public void SendPostRequest(
			string url,
			string data,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null)
		{
			_requestCount++;
			headers = UpdateHeaders(headers);
			_net.SendPostRequest(url, data, timeout, headers, resp => {
				_requestCount--;
				if ( onComplete != null ) {
					onComplete(resp);
				}
			});
		}

		public void SendJsonPostRequest(
			string url,
			string data,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null)
		{
			_requestCount++;
			headers = UpdateHeaders(headers);
			_net.SendJsonPostRequest(url, data, timeout, headers, resp => {
				_requestCount--;
				if ( onComplete != null ) {
					onComplete(resp);
				}
			});
		}

		public void SendDeleteRequest(
			string url,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null) {
			_requestCount++;
			headers = UpdateHeaders(headers);
			_net.SendDeleteRequest(url, timeout, headers, resp => {
				_requestCount--;
				if ( onComplete != null ) {
					onComplete(resp);
				}
			});
		}
	}
}
