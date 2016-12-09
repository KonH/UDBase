using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UDBase.Controllers.InventorySystem {
	public class ItemFactory {

		Dictionary<string, Type> _typeNameToTypes = new Dictionary<string, Type>();

		public void AddType<T>(string typeName) {
			_typeNameToTypes.Add(typeName, typeof(T));
		}

		public Type GetItemType(string typeName) {
			Type type = null;
			_typeNameToTypes.TryGetValue(typeName, out type);
			if ( type == null ) {
				return typeof(InventoryItem);
			} else {
				return type;
			}
		}

		public InventoryItem CreateItem(string typeName) {
			var itemType = GetItemType(typeName);
			return Activator.CreateInstance(itemType) as InventoryItem;
		}
	}
}
