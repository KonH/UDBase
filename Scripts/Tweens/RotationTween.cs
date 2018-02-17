using UnityEngine;
using DG.Tweening;
using UDBase.Utils;

namespace UDBase.Tweens {
	/// <summary>
	/// Tween helper for rotation with visual setup
	/// </summary>
	[AddComponentMenu("UDBase/Tweens/RotationTween")]
	public class RotationTween : MonoBehaviour {
		[Tooltip("Starts automatically?")]
		public bool       AutoPlay = true;
		public Vector3    EndValue = Vector3.zero;
		public float      Duration = 0.0f;
		public RotateMode Mode     = RotateMode.Fast;
		public int        Loops    = -1;
		public Ease       Ease     = Ease.Unset;

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
