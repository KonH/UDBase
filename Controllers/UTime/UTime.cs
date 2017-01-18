using System;

namespace UDBase.Controllers.UTime {
	public class UTime : ControllerHelper<ITime> {

		public static bool IsStableTime() {
			bool isStable = true;
			for( int i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				bool stable = instance.IsAvailable || instance.IsFailed;
				isStable = isStable && stable;
			}
			return isStable;
		}

		public static DateTime CurrentTime() {
			DateTime dt = default(DateTime);
			for( int i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( instance.IsAvailable ) {
					dt = instance.CurrentTime;
				}
			}
			return dt;
		}
	}
}
