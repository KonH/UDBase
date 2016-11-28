using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventoryItem {

		string Name { get; }
		string Type { get; }

		void Init();
		void Load();
	}
}
