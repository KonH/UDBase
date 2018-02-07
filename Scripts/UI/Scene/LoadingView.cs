using System;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;
using Zenject;

namespace UDBase.Controllers.SceneSystem.UI {
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
