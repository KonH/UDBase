﻿using System;
using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.UI.Common {

	/// <summary>
	/// Set element visibility from transparent to solid when shown
	/// </summary>
	[AddComponentMenu("UDBase/UI/FadeAnimation")]
	[RequireComponent(typeof(CanvasGroup))]
    public class UIFadeAnimation : UIShowHideAnimation {

		/// <summary>
		/// Duration of both animations
		/// </summary>
		[Tooltip("Duration of both animations")]
		public float Duration = 1.0f;
		
		Sequence _seq;

		CanvasGroup _group;
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

        public override void Show(UIElement element, Action action) {
			if( !HasShowAnimation ) {
				SetShown();
				action();
				return;
			}
			SetHidden();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(1, Duration));
			_seq.AppendCallback(() => action());
        }

		public override void SetHidden() {
			Group.alpha = 0;
		}

		public override void Hide(UIElement element, Action action) {
			if( !HasHideAnimation ) {
				SetHidden();
				action();
				return;
			}
			SetShown();
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(Group.DOFade(0, Duration));
			_seq.AppendCallback(() => action());
        }

		public override void Clear() {
			if( _seq != null ) {
				_seq = TweenHelper.Reset(_seq);
			}
		}
    }
}
