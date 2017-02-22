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
			if( Instance != null ) {
				Instance.AddItem(holderName, itemName);
			}
		}

		public static void AddItem(string holderName, InventoryItem item) {
			if( Instance != null ) {
				Instance.AddItem(holderName, item);
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

		public static bool CanSend(string fromHolder, string toHolder, InventoryItem item) {
			if( Instance != null ) {
				return Instance.CanSend(fromHolder, toHolder, item);
			}
			return false;
		}

		public static void Send(string fromHolder, string toHolder, InventoryItem item) {
			if( Instance != null ) {
				Instance.Send(fromHolder, toHolder, item);
			}
		}

		public static bool CanSend(string fromHolder, string toHolder, InventoryPack pack, int count) {
			if( Instance != null ) {
				return Instance.CanSend(fromHolder, toHolder, pack, count);
			}
			return false;
		}

		public static void Send(string fromHolder, string toHolder, InventoryPack pack, int count) {
			if( Instance != null ) {
				Instance.Send(fromHolder, toHolder, pack, count);
			}
		}
	}
}
