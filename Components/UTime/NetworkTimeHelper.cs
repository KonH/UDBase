using UnityEngine;
using System.Collections;

namespace UDBase.Components.UTime {
	public class NetworkTimeHelper : MonoBehaviour {

		public void Execute(IEnumerator coroutine) {
			StartCoroutine(coroutine);
		}
	}
}
