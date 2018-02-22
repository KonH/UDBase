using System;
using UnityEngine;

namespace UDBase.UI.Common {

	/// <summary>
	/// Base class for full-cycle animations
	/// </summary>
	public abstract class UIShowHideAnimation : MonoBehaviour, IShowAnimation, IHideAnimation, IClearAnimation {

		/// <summary>
		/// Direction of animation
		/// </summary>
		public enum AnimationDirection {

			/// <summary>
			/// Both show and hide
			/// </summary>
			ShowHide,

			/// <summary>
			/// Only show
			/// </summary>
			Show,

			/// <summary>
			/// Only hide
			/// </summary>
			Hide,

			/// <summary>
			/// None
			/// </summary>
			None
		}

		/// <summary>
		/// Desired animation direction
		/// </summary>
		[Tooltip("Desired animation direction")]
		public AnimationDirection Direction = AnimationDirection.ShowHide;

		/// <summary>
		/// Needs to show animation?
		/// </summary>
		protected bool HasShowAnimation {
			get {
				return 
					(Direction == AnimationDirection.ShowHide) ||
					(Direction == AnimationDirection.Show);
			}
		}

		/// <summary>
		/// Heeds to hide animation?
		/// </summary>
		protected bool HasHideAnimation {
			get {
				return 
					(Direction == AnimationDirection.ShowHide) ||
					(Direction == AnimationDirection.Hide);
			}
		}

		public abstract void SetShown();
		public abstract void Show(UIElement element, Action action);
		public abstract void SetHidden();
		public abstract void Hide(UIElement element, Action action);
		public abstract void Clear();
    }
}
