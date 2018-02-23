using System;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.UI.Common {

	/// <summary>
	/// Controller to play animation combinations on UI element
	/// </summary>
	[AddComponentMenu("UDBase/UI/AnimationController")]
    public class UIAnimationController : MonoBehaviour, IShowAnimation, IHideAnimation, IClearAnimation {

		/// <summary>
		/// Shoud animations played step by step?
		/// </summary>
		[Tooltip("Shoud animations played step by step?")]
		public bool StepByStep = true;

		/// <summary>
		/// All show animations
		/// </summary>
		[Tooltip("All show animations")]
		public List<UIShowHideAnimation> ShowSteps = new List<UIShowHideAnimation>();

		/// <summary>
		/// All hide animations
		/// </summary>
		[Tooltip("All hide animations")]
		public List<UIShowHideAnimation> HideSteps = new List<UIShowHideAnimation>();

		List<UIShowHideAnimation> _showTemp = new List<UIShowHideAnimation>();
		List<UIShowHideAnimation> _hideTemp = new List<UIShowHideAnimation>();

		public void Clear() {
			for( int i = 0; i < ShowSteps.Count; i++ ) {
				ShowSteps[i].Clear();
			}
			for( int i = 0; i < HideSteps.Count; i++ ) {
				HideSteps[i].Clear();
			}
        }

		public void Show(UIElement element, Action action) {
			if( StepByStep ) {
				ShowStep(0, element, action);
			} else {
				_showTemp.AddRange(ShowSteps);
				for( int i = 0; i < ShowSteps.Count; i++ ) {
					var anim = ShowSteps[i];
					anim.Show(element, () => ShowParallelCallback(anim, action));
				}
			}
        }

		void ShowStep(int index, UIElement element, Action callback) {
			if( index < ShowSteps.Count ) {
				ShowSteps[index].Show(element, () => ShowStep(index + 1, element, callback));
			} else {
				callback();
			}
		}

		void ShowParallelCallback(UIShowHideAnimation anim, Action callback) {
			_showTemp.Remove(anim);
			if( _showTemp.Count == 0 ) {
				callback();
			}
		}

        public void SetShown() {
			for( int i = 0; i < ShowSteps.Count; i++ ) {
				ShowSteps[i].SetShown();
			}
		}

        public void Hide(UIElement element, Action action) {
			if( StepByStep ) {
				HideStep(0, element, action);
			} else {
				_hideTemp.AddRange(HideSteps);
				for( int i = 0; i < HideSteps.Count; i++ ) {
					var anim = HideSteps[i];
					anim.Hide(element, () => HideParallelCallback(anim, action));
				}
			}
        }

		void HideStep(int index, UIElement element, Action callback) {
			if( index < HideSteps.Count ) {
				HideSteps[index].Hide(element, () => HideStep(index + 1, element, callback));
			} else {
				callback();
			}
		}

		void HideParallelCallback(UIShowHideAnimation anim, Action callback) {
			_hideTemp.Remove(anim);
			if( _hideTemp.Count == 0 ) {
				callback();
			}
		}

        public void SetHidden() {
			for( int i = 0; i < HideSteps.Count; i++ ) {
				HideSteps[i].SetHidden();
			}
		}
    }
}
