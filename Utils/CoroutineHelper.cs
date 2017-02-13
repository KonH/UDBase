using System.Collections;
using UnityEngine;

namespace UDBase.Utils {
	public class CoroutineHelper : MonoBehaviour {
		public void Execute(IEnumerator coroutine) {
			StartCoroutine(coroutine);
		}
	}
}
