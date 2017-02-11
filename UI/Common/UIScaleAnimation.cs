using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.UI.Common {
    public class UIScaleAnimation : UIShowHideAnimation
    {
		public float Duration = 1.0f;
		
		Vector3 _originalScale = Vector3.zero;
		Sequence _seq          = null;

		void Awake() {
			_originalScale = transform.localScale;
			if( HasShowAnimation ) {
				transform.localScale = Vector3.zero;
			}
		}

		public override void SetShown() {
			transform.localScale = _originalScale;
		}

        public override void Show(UIElement element) {
			if( !HasShowAnimation ) {
				SetShown();
				element.OnShowComplete();
				return;
			}
			SetHidden();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOScale(_originalScale, Duration));
			_seq.AppendCallback(() => element.OnShowComplete());
        }

		public override void SetHidden() {
			transform.localScale = Vector3.zero;
		}

		public override void Hide(UIElement element) {
			if( !HasHideAnimation ) {
				SetHidden();
				element.OnHideComplete();
				return;
			}
			SetShown();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOScale(Vector3.zero, Duration));
			_seq.AppendCallback(() => element.OnHideComplete());
        }

		public override void Clear() {
			if( _seq != null ) {
				_seq = TweenHelper.Reset(_seq);
			}
		}
    }
}
