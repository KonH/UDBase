﻿using UnityEngine;
using System.Collections;

namespace UDBase.Controllers.InventorySystem {
	public interface IInventoryPack {

		string Name  { get; }
		int    Count { get; set; }

		void Init();
		void Load();
	}
}
