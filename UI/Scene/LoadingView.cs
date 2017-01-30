using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.LogSystem;
using UDBase.Utils;

namespace UDBase.Controllers.SceneSystem.UI {
	public class LoadingView : MonoBehaviour {
		[Header("Dependencies")]
		public Image ProgressBar = null;
		public Text  PercentText = null;

		[Header("Settings")]
		public int PercentDecimals = 0;

		AsyncLoadHelper _helper   = null;
		float           _progress = 0.0f;

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
