using UnityEngine;

namespace UDBase.UI.Common {
	public abstract class UIShowHideAnimation : MonoBehaviour, IShowAnimation, IHideAnimation {
		public enum AnimationDirection {
			ShowHide,
			Show,
			Hide,
			None
		}

		public AnimationDirection Direction = AnimationDirection.ShowHide;

		protected bool HasShowAnimation {
			get {
				return 
					(Direction == AnimationDirection.ShowHide) ||
					(Direction == AnimationDirection.Show);
			}
		}

		protected bool HasHideAnimation {
			get {
				return 
					(Direction == AnimationDirection.ShowHide) ||
					(Direction == AnimationDirection.Hide);
			}
		}

        public abstract void Show(UIElement element);

        public abstract  void Hide(UIElement element);
    }
}
