using UnityEngine;
using UnityEngine.UI;

namespace UDBase.UI.Custom {
	[RequireComponent(typeof(Text))]
	public class AppVersionText : MonoBehaviour {
		[Tooltip("Must contains {0} placeholder")]
		public string VersionFormat;

		void Start() {
			var text = GetComponent<Text>();
			text.text = 
				string.IsNullOrEmpty(VersionFormat)
				? Application.version
				: string.Format(VersionFormat, Application.version);
		}
	}
}
