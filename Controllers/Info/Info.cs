using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UDBase.Controllers;

namespace UDBase.Controllers.InfoSystem {
	public class Info : ControllerHelper<IInfoBase> {
		static Dictionary<Type, IInfoBase> TypeDictionary = new Dictionary<Type, IInfoBase>();

		public override void Attach(IController handler) {
			base.Attach(handler);
			var holder = handler as IInfoBase;
			TypeDictionary.Add(holder.GetInfoType(), holder);
		}

		public static T GetInfo<T>(string name) {
			var type = typeof(T);
			IInfoBase holder;
			TypeDictionary.TryGetValue(type, out holder);
			var typeHolder = holder as IInfo<T>;
			if( typeHolder != null ) {
				return typeHolder.GetInfo(name);
			}
			return default(T);
		}
	}
}
