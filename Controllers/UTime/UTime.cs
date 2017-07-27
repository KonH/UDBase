using System;

namespace UDBase.Controllers.UTime {
	public class UTime : ControllerHelper<ITime> {

		public static bool IsStable() {
			var isStable = true;
			for ( var i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				var stable = instance.IsAvailable || instance.IsFailed;
				isStable = isStable && stable;
			}
			return isStable;
		}

		public static bool IsTrusted() {
			for ( var i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( instance.IsTrusted && instance.IsAvailable ) {
					return true;
				}
			}
			return false;
		}
		
		public static DateTime GetTrustedTime() {
			for ( var i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( instance.IsTrusted && instance.IsAvailable ) {
					return instance.CurrentTime;
				}
			}
			return default(DateTime);
		}

		public static DateTime GetUntrustedTime() {
			for ( var i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( !instance.IsTrusted && instance.IsAvailable ) {
					return instance.CurrentTime;
				}
			}
			return default(DateTime);
		}

		public static DateTime GetAvailableTime() {
			return IsTrusted() ? GetTrustedTime() : GetUntrustedTime();
		}
	}
}
