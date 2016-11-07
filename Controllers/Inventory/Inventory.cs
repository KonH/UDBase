using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public class Inventory: ControllerHelper<IInventoryBase> {

		public static int GetPackCount(string holderName, string packName) {
			var count = 0;
			for( int i = 0; i < Instances.Count; i++ ) {
				count += Instances[i].GetPackCount(holderName, packName);
			}
			return count;
		}

		public static void AddToPack(string holderName, string packName, int count) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].AddToPack(holderName, packName, count);
			}
		}
	}
}
