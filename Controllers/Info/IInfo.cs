using UnityEngine;
using System;
using System.Collections;

namespace UDBase.Controllers.InfoSystem {
	public interface IInfoBase:IController {
		Type GetInfoType();
	}

	public interface IInfo<T>:IInfoBase {
		T GetInfo(string name);
	}
}
