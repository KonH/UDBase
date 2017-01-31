using System;

namespace UDBase.Controllers.UTime {
	public class UTime : ControllerHelper<ITime> {

		public static bool IsStable() {
			bool isStable = true;
			for( int i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				bool stable = instance.IsAvailable || instance.IsFailed;
				isStable = isStable && stable;
			}
			return isStable;
		}

		public static bool IsTrusted() {
			for( int i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( instance.IsTrusted && instance.IsAvailable ) {
					return true;
				}
			}
			return false;
		}
		
		public static DateTime GetTrustedTime() {
			for( int i = 0; i < Instances.Count; i++ ) {
				var instance = Instances[i];
				if( instance.IsTrusted && instance.IsAvailable ) {
					return instance.CurrentTime;
				}
			}
			return default(DateTime);
		}

		public static DateTime GetUntrustedTime() {
			for( int i = 0; i < Instances.Count; i++ ) {
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
