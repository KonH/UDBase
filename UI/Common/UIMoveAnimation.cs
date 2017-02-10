using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.UI.Common {
    public class UIMoveAnimation : UIShowHideAnimation
    {
		public float Duration = 1.0f;
		
		public Vector3 Offset = Vector3.zero;

		Vector3 _originalPosition = Vector3.zero;
		Sequence _seq             = null;

		void Awake() {
			_originalPosition = transform.localPosition;
			if( HasShowAnimation ) {
				transform.localPosition += Offset;
			}
		}

        public override void Show(UIElement element) {
			if( !HasShowAnimation ) {
				transform.localPosition = _originalPosition;
				element.OnShowComplete();
				return;
			}
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOLocalMove(_originalPosition, Duration));
			_seq.AppendCallback(() => element.OnShowComplete());
        }

		public override void Hide(UIElement element) {
			if( !HasHideAnimation ) {
				element.OnHideComplete();
				return;
			}
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOLocalMove(_originalPosition + Offset, Duration));
			_seq.AppendCallback(() => element.OnHideComplete());
        }
    }
}
