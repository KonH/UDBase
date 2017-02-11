using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.UI.Common {
	[RequireComponent(typeof(CanvasGroup))]
    public class UIFadeAnimation : UIShowHideAnimation
    {
		public float Duration = 1.0f;
		Sequence _seq = null;

		CanvasGroup _group = null;
		CanvasGroup Group {
			get {
				if( !_group ) {
					_group = GetComponent<CanvasGroup>();
				}
				return _group;
			}
		}

		void Awake() {
			if( HasShowAnimation ) {
				Group.alpha = 0;
			}
		}

		public override void SetShown() {
			Group.alpha = 1;
		}

        public override void Show(UIElement element) {
			if( !HasShowAnimation ) {
				SetShown();
				element.OnShowComplete();
				return;
			}
			SetHidden();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(1, Duration));
			_seq.AppendCallback(() => element.OnShowComplete());
        }

		public override void SetHidden() {
			Group.alpha = 0;
		}

		public override void Hide(UIElement element) {
			if( !HasHideAnimation ) {
				SetHidden();
				element.OnHideComplete();
				return;
			}
			SetShown();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(0, Duration));
			_seq.AppendCallback(() => element.OnHideComplete());
        }

		public override void Clear() {
			if( _seq != null ) {
				_seq = TweenHelper.Reset(_seq);
			}
		}
    }
}
