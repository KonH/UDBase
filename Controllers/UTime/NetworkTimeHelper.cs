using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.UTime {
	public class NetworkTimeHelper : MonoBehaviour {

		public void Execute(IEnumerator coroutine) {
			StartCoroutine(coroutine);
		}
	}
}
