using DG.Tweening;

namespace UDBase.Utils {
	public static class TweenHelper {
		public static Sequence Replace(Sequence seq, bool complete = false) {
			if( seq != null ) {
				seq = Reset(seq, complete);
			}
			return DOTween.Sequence();
		}

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
