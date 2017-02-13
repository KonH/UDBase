using System;
using System.Collections;
using UnityEngine;

namespace UDBase.Utils {
	public static class NetUtils {
		
		public class Response {
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
			
			public Response(string text, string error, bool timeout) {
				Text    = text;
				Error   = error;
				Timeout = timeout;
			} 
		}

		public static void SendRequest(string url, float timeout, Action<Response> onComplete) {
			UnityHelper.StartCoroutine(RequestCoroutine(url, timeout, onComplete));
		}

		static float CurrentTime {
			get {
				return Time.realtimeSinceStartup;
			}
		}
		static IEnumerator RequestCoroutine(string url, float timeout, Action<Response> onComplete) {
			var request = new WWW(url);
			var startTime = CurrentTime;
			var isTimeout = false;
			while( !request.isDone ) {
				if( CurrentTime - startTime > timeout ) {
					isTimeout = true;
					break;
				}
				yield return null;
			}
			var response = new Response(request.text, request.error, isTimeout);
			if( onComplete != null ) {
				onComplete(response);
			}
		}
	}
}
