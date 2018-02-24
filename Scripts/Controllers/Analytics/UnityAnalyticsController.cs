using System.Text;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UDBase.Utils;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.AnalyticsSystem {
	public class UnityAnalyticsController : IAnalytics, ILogContext {

		ILog _log;

		public UnityAnalyticsController(ILog log) {
			_log = log;
		}

		public void Event(string eventName) {
			var result = Analytics.CustomEvent(eventName);
			_log.MessageFormat(this, "Fired event: '{0}', result: {1}", eventName, result);
		}

		public void Event(string eventName, Dictionary<string, object> data) {
			var result = Analytics.CustomEvent(eventName, data);
			var getDataInfo = new StringFunctor(() => {
				var dataSb = new StringBuilder();
				foreach (var item in data) {
					dataSb.AppendFormat("'{0}' => '{1}';", item.Key, item.Value);
				}
				return dataSb.ToString();
			});
			_log.MessageFormat(this, "Fired event: '{0}' with data: {1}, result: {2}", eventName, getDataInfo, result);
		}
	}
}
