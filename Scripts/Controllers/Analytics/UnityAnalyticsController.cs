using UnityEngine.Analytics;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.AnalyticsSystem {
	public class UnityAnalyticsController : IAnalytics, ILogContext {

		ILog _log;

		public UnityAnalyticsController(ILog log) {
			_log = log;
		}
	}
}
