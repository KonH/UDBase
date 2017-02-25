using System;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.UI.Common {
    public class UIAnimationController : MonoBehaviour, IShowAnimation, IHideAnimation, IClearAnimation {

		public List<UIShowHideAnimation> ShowSteps = new List<UIShowHideAnimation>();
		public List<UIShowHideAnimation> HideSteps = new List<UIShowHideAnimation>();

		public void Clear() {
			for( int i = 0; i < ShowSteps.Count; i++ ) {
				ShowSteps[i].Clear();
			}
			for( int i = 0; i < HideSteps.Count; i++ ) {
				HideSteps[i].Clear();
			}
        }

		public void Show(UIElement element, Action action) {
			SetShown();
			ShowStep(0, element, action);
        }

		void ShowStep(int index, UIElement element, Action callback) {
			if( index < ShowSteps.Count ) {
				ShowSteps[index].Show(element, () => ShowStep(index + 1, element, callback));
			} else {
				callback();
			}
		}

        public void SetShown() {
			for( int i = 0; i < HideSteps.Count; i++ ) {
				HideSteps[i].SetShown();
			}
        }

        public void Hide(UIElement element, Action action) {
			SetHidden();
			HideStep(0, element, action);
        }

		void HideStep(int index, UIElement element, Action callback) {
			if( index < HideSteps.Count ) {
				HideSteps[index].Show(element, () => HideStep(index + 1, element, callback));
			} else {
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
