using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UDBase.Controllers.LogSystem;
using Zenject;

namespace UDBase.Utils {

	/// <summary>
	/// Utility to perform web requests
	/// </summary>
	public class NetUtils : MonoBehaviour, ILogContext {

		/// <summary>
		/// Default request timeout value
		/// </summary>
		public const float DefaultTimeout = 10.0f;

		/// <summary>
		/// Request response wrapper
		/// </summary>
		public class Response {

			/// <summary>
			/// Respronse conde
			/// </summary>
			public long Code { get; private set; }

			/// <summary>
			/// Data as text
			/// </summary>
			public string Text { get; private set; }

			/// <summary>
			/// Error text
			/// </summary>
			public string Error { get; private set; }

			/// <summary>
			/// Is it failed by timeout
			/// </summary>
			public bool Timeout { get; private set; }

			/// <summary>
			/// Response headers
			/// </summary>
			public Dictionary<string, string> Headers { get; private set; }

			/// <summary>
			/// Is error happen?
			/// </summary>
			public bool HasError {
				get {
					return !string.IsNullOrEmpty(Error);
				}
			}

			/// <summary>
			/// Is response empty?
			/// </summary>
			public bool IsEmpty { 
				get {
					return string.IsNullOrEmpty(Text);
				}
			}
			
			internal Response(long code, string text, string error, Dictionary<string, string> headers, bool timeout) {
				Code    = code;
				Text    = text;
				Error   = error;
				Headers = headers;
				Timeout = timeout;
			}

			/// <summary>
			/// Safety get concrete header value by its name
			/// </summary>
			public string GetHeader(string name) {
				string value = null;
				if ( Headers != null ) {
					Headers.TryGetValue(name, out value);
				}
				return value;
			}

			/// <summary>
			/// Return text if it isn't empty or error and code instread
			/// </summary>
			public string GetNonEmptyText() {
				return !string.IsNullOrEmpty(Text) ?
					Text :
					string.Format("{0} ({1})", Error, Code.ToString());
			}
		}

		ULogger _log;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Initialize(ILog log) {
			_log = log.CreateLogger(this);
		}

		/// <summary>
		/// Creates the basic authorization header value by user name and password
		/// </summary>
		public string CreateBasicAuthorization(string userName, string userPassword) {
			var prefix = "Basic ";
			var userPassBlock = Encoding.ASCII.GetBytes(userName + ":" + userPassword);
			var base64String = Convert.ToBase64String(userPassBlock);
			return prefix + base64String;
		}

		UnityWebRequest CreateGetRequest(string url) {
			return UnityWebRequest.Get(url);
		}

		UnityWebRequest CreatePostRequest(string url, string data) {
			return UnityWebRequest.Post(url, data);
		}

		UnityWebRequest CreateJsonPostRequest(string url, string data) {
			var req = UnityWebRequest.Post(url, UnityWebRequest.kHttpVerbPOST);
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			UploadHandlerRaw uploadHandler = new UploadHandlerRaw(bytes);
			uploadHandler.contentType = "application/json";
			req.uploadHandler = uploadHandler;
			return req;
		}

		UnityWebRequest CreateDeleteRequest(string url) {
			return UnityWebRequest.Delete(url);
		}

		/// <summary>
		/// Sends the get request
		/// </summary>
		public void SendGetRequest(
			string url,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null) 
		{
			var req = CreateGetRequest(url);
			SendRequest(req, timeout, headers, onComplete);
		}

		/// <summary>
		/// Sends the post request
		/// </summary>
		public void SendPostRequest(
			string url,
			string data,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null) 
		{
			var req = CreatePostRequest(url, data);
			SendRequest(req, timeout, headers, onComplete);
		}

		/// <summary>
		/// Sends the post request with 'application/json' contentType
		/// </summary>
		public void SendJsonPostRequest(
			string url,
			string data,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null)
		{
			var req = CreateJsonPostRequest(url, data);
			SendRequest(req, timeout, headers, onComplete);
		}

		/// <summary>
		/// Sends the delete request
		/// </summary>
		public void SendDeleteRequest(
			string url,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null) 
		{
			var req = CreateDeleteRequest(url);
			SendRequest(req, timeout, headers, onComplete);
		}

		/// <summary>
		/// Sends the request
		/// </summary>
		public void SendRequest(
			UnityWebRequest request, 
			float timeout = DefaultTimeout, 
			Dictionary<string, string> headers = null, 
			Action<Response> onComplete = null)
		{
			AddHeaders(request, headers);
			StartCoroutine(RequestCoroutine(request, timeout, onComplete));
		}

		float CurrentTime {
			get {
				return Time.realtimeSinceStartup;
			}
		}

		/// <summary>
		/// Add given header to request
		/// </summary>
		public void AddHeader(UnityWebRequest request, string name, string value) {
			request.SetRequestHeader(name, value);
		}

		/// <summary>
		/// Add given headers to request
		/// </summary>
		public void AddHeaders(UnityWebRequest request, Dictionary<string, string> headers) {
			if ( headers != null ) {
				var iter = headers.GetEnumerator();
				while ( iter.MoveNext() ) {
					var header = iter.Current;
					AddHeader(request, header.Key, header.Value);
				}
			}
		}

		IEnumerator RequestCoroutine(UnityWebRequest request, float timeout, Action<Response> onComplete) {
			using ( request ) {
				var startTime = CurrentTime;
				var isTimeout = false;
				var operation = request.SendWebRequest();
				while ( !operation.isDone ) {
					if ( CurrentTime - startTime > timeout ) {
						isTimeout = true;
						break;
					}
					yield return null;
				}
				ProcessRequestResult(request, isTimeout, onComplete);
			}
		}

		void ProcessRequestResult(UnityWebRequest request, bool isTimeout, Action<Response> onComplete) {
			var url = request.url;
			var response = new Response(
				request.responseCode,
				request.downloadHandler != null ? request.downloadHandler.text : null,
				request.error,
				request.GetResponseHeaders(),
				isTimeout);
			if ( isTimeout ) {
				_log.ErrorFormat("Request to '{0}': timeout", url);
			} else if ( request.isNetworkError ) {
				_log.ErrorFormat("Request to '{0}': error: '{1}'", url, request.error);
			} else {
				_log.MessageFormat("Request to '{0}': response code: {1}, text: '{2}'", url, request.responseCode, response.Text);
			}
			onComplete?.Invoke(response);
		}
	}
}
