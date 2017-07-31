using System;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;

namespace UDBase.Controllers.SceneSystem.UI {
	public class LoadingView : MonoBehaviour {
		[Header("Dependencies")]
		public Image ProgressBar;
		public Text  PercentText;

		[Header("Settings")]
		public int PercentDecimals;

		AsyncLoadHelper _helper;
		float           _progress;

		void Start () {
			Init();
			UpdateState();
		}

		void Init() {
			_helper = UnityHelper.GetComponent<AsyncLoadHelper>();
			if( !_helper ) {
				enabled = false;
				Log.Error("No AsyncLoadHelper is found!", LogTags.UI);
			}
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
