using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.Tweens {
	/// <summary>
	/// Tween helper for rotation with visual setup
	/// </summary>
	[AddComponentMenu("UDBase/Tweens/RotationTween")]
	public class RotationTween : MonoBehaviour {

		/// <summary>
		/// Starts automatically?
		/// </summary>
		[Tooltip("Starts automatically?")]
		public bool AutoPlay = true;

		/// <summary>
		/// End rotation value
		/// </summary>
		[Tooltip("End rotation value")]
		public Vector3 EndValue = Vector3.zero;

		/// <summary>
		/// Full rotation time
		/// </summary>
		[Tooltip("Full rotation time")]
		public float Duration;

		/// <summary>
		/// DOTween rotation mode
		/// </summary>
		[Tooltip("DOTween rotation mode")]
		public RotateMode Mode = RotateMode.Fast;

		/// <summary>
		/// How many loops required? (-1 = unlimited)
		/// </summary>
		[Tooltip("How many loops required? (-1 = unlimited)")]
		public int Loops = -1;

		/// <summary>
		/// DOTween ease mode
		/// </summary>
		[Tooltip("DOTween ease mode")]
		public Ease Ease = Ease.Unset;

		Sequence _seq;

		void OnEnable() {
			if ( AutoPlay ) {
				StartAnimation();
			}
		}

		void OnDisable() {
			StopAnimation();
		}

		/// <summary>
		/// Start animation with current parameters
		/// </summary>
		public void StartAnimation() {
			_seq = TweenHelper.Replace(_seq);
			_seq.Append(transform.DORotate(EndValue, Duration, Mode));
			_seq.SetLoops(Loops);
			_seq.SetEase(Ease);
		}

		/// <summary>
		/// Stop animation (if started)
		/// </summary>
		public void StopAnimation() {
			_seq = TweenHelper.Reset(_seq);
		}

	}
}
