using System;
using System.Text;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.Assertions;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.AnalyticsSystem {

	/// <summary>
	/// Analytics controller which uses Unity Analytics
	/// </summary>
	public class UnityAnalyticsController : IAnalytics, ILogContext {
		Dictionary<string, object> _tempDict    = new Dictionary<string, object>();
		Dictionary<string, object> _sessionData = new Dictionary<string, object>();

		ILog _log;

		public UnityAnalyticsController(ILog log) {
			_log = log;
		}

		public void Event(string eventName) {
			Assert.IsNotNull(eventName);
			if ( _sessionData.Count > 0 ) {
				_tempDict.Clear();
				Event(eventName, _tempDict);
				return;
			}
			var result = Analytics.CustomEvent(eventName);
			_log.MessageFormat(this, "Fired event: '{0}', result: {1}", eventName, result);
		}

		public void Event(string eventName, Dictionary<string, object> userData) {
			Assert.IsNotNull(eventName);
			Assert.IsNotNull(userData);
			var combinedData = CombineData(userData, _sessionData);
			var result = Analytics.CustomEvent(eventName, combinedData);
			var getDataInfo = new StringFunctor(() => {
				var dataSb = new StringBuilder();
				foreach ( var item in combinedData ) {
					dataSb.AppendFormat("'{0}' => '{1}';", item.Key, item.Value);
				}
				return dataSb.ToString();
			});
			_log.MessageFormat(this, "Fired event: '{0}' with data: {1}, result: {2}", eventName, getDataInfo, result);
		}

		public void AddSessionData(string key, object value) {
			Assert.IsNotNull(key);
			Assert.IsNotNull(value);
			if ( !_sessionData.ContainsKey(key) ) {
				_sessionData.Add(key, value);
			} else {
				_sessionData[key] = value;
			}
		}

		public void UpdateSessionData(string key, Func<object, object> valueChange) {
			Assert.IsNotNull(key);
			Assert.IsNotNull(valueChange);
			if ( !_sessionData.ContainsKey(key) ) {
				_sessionData.Add(key, valueChange(null));
			} else {
				var oldValue = _sessionData[key];
				_sessionData[key] = valueChange(oldValue);
			}
		}

		public void RemoveSessionData(string key) {
			Assert.IsNotNull(key);
			_sessionData.Remove(key);
		}

		Dictionary<string, object> CombineData(Dictionary<string, object> userData, Dictionary<string, object> sessionData) {
			if ( sessionData.Count == 0 ) {
				return userData;
			}
			_tempDict.Clear();
			foreach ( var pair in userData ) {
				_tempDict.Add(pair.Key, pair.Value);
			}
			foreach ( var pair in sessionData ) {
				_tempDict.Add(pair.Key, pair.Value);
			}
			return _tempDict;
		}
	}
}
