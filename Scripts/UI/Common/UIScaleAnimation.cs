using System;
using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.UI.Common {

	/// <summary>
	/// Scale element from zero to original when shown
	/// </summary>
	[AddComponentMenu("UDBase/UI/ScaleAnimation")]
    public class UIScaleAnimation : UIShowHideAnimation {

		/// <summary>
		/// Duration of both animations
		/// </summary>
		[Tooltip("Duration of both animations")]
		public float Duration = 1.0f;
		
		Vector3 _originalScale = Vector3.zero;
		Sequence _seq;

		void Awake() {
			_originalScale = transform.localScale;
			if( HasShowAnimation ) {
				transform.localScale = Vector3.zero;
			}
		}

		public override void SetShown() {
			transform.localScale = _originalScale;
		}

        public override void Show(UIElement element, Action action) {
			if( !HasShowAnimation ) {
				SetShown();
				action();
				return;
			}
			SetHidden();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOScale(_originalScale, Duration));
			_seq.AppendCallback(() => action());
        }

		public override void SetHidden() {
			transform.localScale = Vector3.zero;
		}

		public override void Hide(UIElement element, Action action) {
			if( !HasHideAnimation ) {
				SetHidden();
				action();
				return;
			}
			SetShown();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DOScale(Vector3.zero, Duration));
			_seq.AppendCallback(() => action());
        }

		public override void Clear() {
			if( _seq != null ) {
				_seq = TweenHelper.Reset(_seq);
			}
		}
    }
}
