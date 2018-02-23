using System;
using System.Collections.Generic;

namespace UDBase.Utils {

	/// <summary>
	/// HetUtils wrapper to send web requests with authorization
	/// </summary>
	public class WebClient {

		const string AuthHeaderName = "Authorization";

		/// <summary>
		/// Is any request in progress
		/// </summary>
		public bool InProgress {
			get {
				return _requestCount > 0;
			}
		}

		/// <summary>
		/// Is client authorized?
		/// </summary>
		public bool HasAuthorization {
			get {
				return !string.IsNullOrEmpty(_authHeaderValue);
			}
		}

		string                     _authHeaderValue = null;
		Dictionary<string, string> _authHeaderOnly  = null;
		int                        _requestCount    = 0;

		NetUtils _net;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		public WebClient(NetUtils net) {
			_net = net;
			_authHeaderValue = "";
			_authHeaderOnly = new Dictionary<string, string>();
		}

		/// <summary>
		/// Adds the user name and password to use with this client
		/// </summary>
		public void AddUserData(string userName, string userPassword) {
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

		/// <summary>
		/// Adds auth header value
		/// </summary>
		public void ApplyAuthHeader(string value) {
			_authHeaderValue = value;
			_authHeaderOnly = UpdateHeaders(new Dictionary<string, string>());
		}

		/// <summary>
		/// Sends the get request
		/// </summary>
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
				onComplete?.Invoke(resp);
			});
		}

		/// <summary>
		/// Sends the post request.
		/// </summary>
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
				onComplete?.Invoke(resp);
			});
		}

		/// <summary>
		/// Sends the json post request
		/// </summary>
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
				onComplete?.Invoke(resp);
			});
		}

		/// <summary>
		/// Sends the delete request
		/// </summary>
		public void SendDeleteRequest(
			string url,
			float timeout = NetUtils.DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<NetUtils.Response> onComplete = null) {
			_requestCount++;
			headers = UpdateHeaders(headers);
			_net.SendDeleteRequest(url, timeout, headers, resp => {
				_requestCount--;
				onComplete?.Invoke(resp);
			});
		}
	}
}
