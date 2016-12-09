using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public class Inventory: ControllerHelper<IInventory> {

		public static int GetPackCount(string holderName, string packName) {
			if( Instance != null ) {
				return Instance.GetPackCount(holderName, packName);
			}
			return 0;
		}

		public static void AddToPack(string holderName, string packName, int count) {
			if( Instance != null ) {
				Instance.AddToPack(holderName, packName, count);
			}
		}

		public static InventoryPack GetPack(string holderName, string packName) {
			if( Instance != null ) {
				return Instance.GetPack(holderName, packName);
			}
			return null;
		}

		public static List<InventoryPack> GetHolderPacks(string holderName) {
			if( Instance != null ) {
				return Instance.GetHolderPacks(holderName);
			}
			return null;
		}

		public static void RemoveFromPack(string holderName, InventoryPack pack, int count) {
			if( Instance != null ) {
				Instance.RemoveFromPack(holderName, pack, count);
			}
		}

		public static void ClearPack(string holderName, InventoryPack pack) {
			if( Instance != null ) {
				Instance.ClearPack(holderName, pack);
			}
		}

		public static void AddItem(string holderName, string itemName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].AddItem(holderName, itemName);
			}
		}

		public static InventoryItem GetItem(string holderName, string itemName) {
			if( Instance != null ) {
				return Instance.GetItem(holderName, itemName);
			}
			return null;
		}

		public static List<InventoryItem> GetHolderItems(string holderName) {
			if ( Instance != null ) {
				return Instance.GetHolderItems(holderName);
			}
			return null;
		}

		public static void RemoveItem(string holderName, InventoryItem item) {
			if( Instance != null ) {
				Instance.RemoveItem(holderName, item);
			}
		}

		public static void SaveChanges() {
			if( Instance != null ) {
				Instance.SaveChanges();
			}
		}
	}
}
