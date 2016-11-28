using UnityEngine;
using System;
using System.Collections;
using UDBase.Controllers.ConfigSystem;

namespace UDBase.Controllers.InfoSystem {
	public class ConfigInfoHolder<TItem, THolder>:IInfo<TItem>
		where THolder: ConfigInfoNode<TItem>,new()
		where TItem: IInfoItem {

		public void Init() {}
		public void PostInit() {}

		public Type GetInfoType() {
			return typeof(TItem);
		}

		public TItem GetInfo(string name) {
			var holder = Config.GetNode<THolder>();
			if( holder != null ) {
				var items = holder.Items;
				for( int i = 0; i < items.Count; i++ ) {
					if( items[i].Name == name ) {
						return items[i];
					}
				}
			}
			return default(TItem);
		}
	}
}