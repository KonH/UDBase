using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
	/// <summary>
	/// Component to show IScene loading progress on UnityEngine.UI.Text (in percent format) and Image (use fill amount)
	/// </summary>
	[AddComponentMenu("UDBase/UI/Scene/LoadingView")]
	public class LoadingView : MonoBehaviour {
		[Header("Dependencies")]
		public Image ProgressBar;
		public Text  PercentText;

		[Header("Settings")]
		public int PercentDecimals;

		AsyncLoadHelper _helper;
		float           _progress;

		[Inject]
		public void Init(AsyncLoadHelper helper) {
			_helper = helper;
		}

		void Update () {
			UpdateState();
		}
	
		void UpdateState() {
			if( _helper ) {
				_progress = _helper.Progress;
				if( PercentText ) {
					var percents = Math.Round(_progress * 100, PercentDecimals);
					PercentText.text = string.Format("{0}%", percents);
				}
				if( ProgressBar ) {
					ProgressBar.fillAmount = _progress;
				}
			}
		}
	}
}
