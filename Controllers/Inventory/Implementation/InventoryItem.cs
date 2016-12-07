using UnityEngine;
using System;
using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UDBase.Controllers.LogSystem;

namespace UDBase.Controllers.InventorySystem {
	public class InventoryItem {
		[JsonIgnore()]
		public JObject Content { get; private set; }
		[JsonProperty("name")]
		public string Name     { get; private set; }
		[JsonIgnore()]
		public string Type     { get; private set; }

		public InventoryItem() {}

		public InventoryItem(string name, string type) {
			Name = name;
			Type = type;
		}

		public void SetName(string name) {
			Name = name;
		}

		public void SetType(string type) {
			Type = type;
		}

		public void AssignContent(JObject content) {
			Content = content;
		}

		public virtual void Init() {}

		public virtual InventoryItem Clone() {
			return new InventoryItem(Name, Type);
		}

		public T As<T>() {
			try {
				return Content.ToObject<T>();
			} catch ( Exception e ) {
				Log.ErrorFormat(
					"Item [{0}, {1}] is not {2}, details: {3}", 
					LogTags.Inventory, 
					Name, Type, typeof(T).ToString(), e.Message);
			}
			return default(T);
		}
	}
}
