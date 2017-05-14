using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UDBase.Controllers.LogSystem;

namespace UDBase.Utils {
	public static class NetUtils {

		public const float DefaultTimeout = 10.0f;

		public class Response {
			public long   Code    { get; private set; }
			public string Text    { get; private set; }
			public string Error   { get; private set; }
			public bool   Timeout { get; private set; }
			
			public bool HasError {
				get {
					return !string.IsNullOrEmpty(Error);
				}
			}
			public bool IsEmpty { 
				get {
					return string.IsNullOrEmpty(Text);
				}
			}
			
			public Response(long code, string text, string error, bool timeout) {
				Code    = code;
				Text    = text;
				Error   = error;
				Timeout = timeout;
			} 
		}

		public static void SendGetRequest(
			string url,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null) 
		{
			var req = UnityWebRequest.Get(url);
			SendRequest(req, timeout, headers, onComplete);
		}

		public static void SendPostRequest(
			string url,
			string data,
			float timeout = DefaultTimeout,
			Dictionary<string, string> headers = null,
			Action<Response> onComplete = null) 
		{
			var req = UnityWebRequest.Post(url, data);
			SendRequest(req, timeout, headers, onComplete);
		}

		public static void SendRequest(
			UnityWebRequest request, 
			float timeout = DefaultTimeout, 
			Dictionary<string, string> headers = null, 
			Action<Response> onComplete = null)
		{
			AddHeaders(request, headers);
			UnityHelper.StartCoroutine(RequestCoroutine(request, timeout, headers, onComplete));
		}

		static float CurrentTime {
			get {
				return Time.realtimeSinceStartup;
			}
		}

		static void AddHeaders(UnityWebRequest request, Dictionary<string, string> headers) {
			if ( headers != null ) {
				var iter = headers.GetEnumerator();
				while ( iter.MoveNext() ) {
					var header = iter.Current;
					request.SetRequestHeader(header.Key, header.Value);
				}
			}
		}

		static IEnumerator RequestCoroutine(UnityWebRequest request, float timeout, Dictionary<string, string> headers, Action<Response> onComplete) {
			using ( request ) {
				var startTime = CurrentTime;
				var isTimeout = false;
				var operation = request.Send();
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

		static void ProcessRequestResult(UnityWebRequest request, bool isTimeout, Action<Response> onComplete) {
			var url = request.url;
			var response = new Response(
				request.responseCode,
				request.downloadHandler != null ? request.downloadHandler.text : null,
				request.error,
				isTimeout);
			if ( isTimeout ) {
				Log.ErrorFormat("Request to '{0}': timeout", LogTags.Network, url);
			} else if ( request.isError ) {
				Log.ErrorFormat("Request to '{0}': error: '{1}'", LogTags.Network, url, request.error);
			} else {
				Log.MessageFormat("Request to '{0}': response code: {1}, text: '{2}'", LogTags.Network, url, request.responseCode, response.Text);
			}
			if ( onComplete != null ) {
				onComplete(response);
			}
		}
	}
}
