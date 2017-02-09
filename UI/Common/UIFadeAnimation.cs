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

        public override void Show(UIElement element, bool initial) {
			if( !HasShowAnimation ) {
				element.OnShowComplete();
				return;
			}
			if( initial ) {
				Group.alpha = 0;
			}
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(1, Duration));
			_seq.AppendCallback(() => element.OnShowComplete());
        }

		public override void Hide(UIElement element) {
			if( !HasHideAnimation ) {
				element.OnHideComplete();
				return;
			}
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(0, Duration));
			_seq.AppendCallback(() => element.OnHideComplete());
        }
    }
}
