using System.Collections.Generic;
using UnityEngine;

namespace UDBase.UI.Common {
	public class UIElement : MonoBehaviour {
		public static List<UIElement> Instances = new List<UIElement>();

		public enum UIElementState {
			None,
			Showing,
			Shown,
			Hiding,
			Hidden
		}

		public bool   AutoShow       = true;
		public bool   CacheAnimation = true;
		public string Group          = null;
		public UIElementState State { get; private set; }

		UIAnimation _animation = null;

		void Awake() {
			Instances.Add(this);
			if( CacheAnimation ) {
				AssingAnimation(true);
			}
			if( AutoShow ) {
				Show(true);
			}
		}

		void AssingAnimation(bool firstTime = false) {
			if( firstTime || !CacheAnimation ) {
				_animation = GetComponent<UIAnimation>();
			}
		}

		bool CanShow() {
			return 
				(State != UIElementState.Showing) &&
				(State != UIElementState.Shown);
		}

		public void Show(bool initial = false) {
			State = UIElementState.Showing;
			gameObject.SetActive(true);
			AssingAnimation();
			if( _animation ) {
				_animation.Show(this, initial);
			} else {
				OnShowComplete();
			}
		}

		public void OnShowComplete() {
			State = UIElementState.Shown;
		}

		bool CanHide() {
			return 
				(State != UIElementState.Hiding) &&
				(State != UIElementState.Hidden);
		}

		public void Hide() {
			State = UIElementState.Hiding;
			AssingAnimation();
			if( _animation ) {
				_animation.Hide(this);
			} else {
				OnHideComplete();
			}
		}

		public void OnHideComplete() {
			gameObject.SetActive(false);
			State = UIElementState.Hidden;
		}

		void OnDestroy() {
			Instances.Remove(this);
		}
	}
}
