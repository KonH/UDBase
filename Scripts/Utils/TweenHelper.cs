using DG.Tweening;

namespace UDBase.Utils {
	/// <summary>
	/// Helper methods for DG.Tween/Sequence usage
	/// </summary>
	public static class TweenHelper {

		/// <summary>
		/// Reset given sequence and replace it with new
		/// </summary>
		public static Sequence Replace(Sequence seq, bool complete = false) {
			if( seq != null ) {
				seq = Reset(seq, complete);
			}
			return DOTween.Sequence();
		}

		/// <summary>
		/// Reset given sequence
		/// </summary>
		public static Sequence Reset(Sequence seq, bool complete = false) {
			if( seq != null ) {
				if( complete ) {
					seq.Complete();
				}
				seq.Kill();
				seq = null;
			}
			return seq;
		}
	}
}
