﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace UDBase.Controllers.InventorySystem {
	public interface IItemHolder<TItem, TPack>
		where TItem:IInventoryItem where TPack:IInventoryPack {

		string Name { get; set; }

		TPack       GetPack       (string name);
		List<TPack> GetPacks      ();
		void        AddToPack     (string name, int count);
		void        RemoveFromPack(TPack pack, int count);
		void        ClearPack     (TPack pack);
		TItem       GetItem       (string name);
		List<TItem> GetItems      ();
		void        AddItem       (string name);
		void        RemoveItem    (TItem item);
	}
}
