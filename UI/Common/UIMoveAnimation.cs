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

		public override void SetShown() {
			transform.localPosition = _originalPosition;
		}

        public override void Show(UIElement element) {
			if( !HasShowAnimation ) {
				SetShown();
				element.OnShowComplete();
				return;
			}
			SetHidden();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOLocalMove(_originalPosition, Duration));
			_seq.AppendCallback(() => element.OnShowComplete());
        }

		public override void SetHidden() {
			transform.localPosition = _originalPosition + Offset;
		}

		public override void Hide(UIElement element) {
			if( !HasHideAnimation ) {
				SetHidden();
				element.OnHideComplete();
				return;
			}
			SetShown();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOLocalMove(_originalPosition + Offset, Duration));
			_seq.AppendCallback(() => element.OnHideComplete());
        }

		public override void Clear() {
			if( _seq != null ) {
				_seq = TweenHelper.Reset(_seq);
			}
		}
    }
}
