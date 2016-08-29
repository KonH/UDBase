using UnityEngine;
using System.Collections;
using UDBase.Components;

namespace UDBase.Components.Save {
	public class Save:ComponentHelper<ISave> {

		public static T GetNode<T>() where T:class, ISaveNode, new() {
			if( Instance != null ) {
				return Instance.GetNode<T>();
			}
			return null;
		}

		public static void SaveNode<T>(T node) where T:class, ISaveNode, new() {
			if( Instance != null ) {
				Instance.SaveNode(node);
			}
		}
	}
}
