using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

		public static TPack GetPack<TPack>(string holderName, string packName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				var pack = Instances[i].GetPack<TPack>(holderName, packName);
				if( pack != null ) {
					return pack;
				}
			}
			return default(TPack);
		}

		public static List<TPack> GetHolderPacks<TPack>(string holderName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				var packs = Instances[i].GetHolderPacks<TPack>(holderName);
				if( packs != null ) {
					return packs;
				}
			}
			return null;
		}

		public static void RemoveFromPack<TPack>(string holderName, TPack pack, int count) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].RemoveFromPack<TPack>(holderName, pack, count);
			}
		}

		public static void ClearPack<TPack>(string holderName, TPack pack) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].ClearPack<TPack>(holderName, pack);
			}
		}

		public static void AddItem(string holderName, string itemName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].AddItem(holderName, itemName);
			}
		}

		public static TItem GetItem<TItem>(string holderName, string itemName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				var packs = Instances[i].GetItem<TItem>(holderName, itemName);
				if( packs != null ) {
					return packs;
				}
			}
			return default(TItem);
		}

		public static List<TItem> GetHolderItems<TItem>(string holderName) {
			for( int i = 0; i < Instances.Count; i++ ) {
				var packs = Instances[i].GetHolderItems<TItem>(holderName);
				if( packs != null ) {
					return packs;
				}
			}
			return null;
		}

		public static void RemoveItem<TItem>(string holderName, TItem item) {
			for( int i = 0; i < Instances.Count; i++ ) {
				Instances[i].RemoveItem<TItem>(holderName, item);
			}
		}
	}
}
