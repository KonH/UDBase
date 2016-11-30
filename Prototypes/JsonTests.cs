using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class JsonTests : MonoBehaviour {

	class ConfigNode {
	}

	class ConfigNodeInt:ConfigNode {
		public int data;
	}

	class NodeItem {
		public string name;
	}

	class ConfigNodeList:ConfigNode {
		public List<NodeItem> items;
	}

	class BaseItem {
		public string name;
		public string type;
		public int cost;
	}

	class WeaponItem {
		public int damage;
	}

	Dictionary<string, JObject> _config;
	Dictionary<Type, string> _configNames;
	Dictionary<Type, object> _configCache;

	List<JObject> _itemList;
	List<BaseItem> _itemBases;
	Dictionary<BaseItem, JObject> _itemBinds;
	Dictionary<BaseItem, object> _itemCache;

	// Use this for initialization
	void Start () {
		Test();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Test() {
		var jsonConfig = 
			"{\"configNode1\": { \"data\": 42}," +
			"\"configNode2\": { \"items\": [ {\"name\":\"item1\"}, {\"name\":\"item2\"}]}\n}";

		_config = JsonConvert.DeserializeObject<Dictionary<string, JObject>>(jsonConfig);

		// Test
		Debug.Log("CONFIG:");
		Debug.Log(_config.Count);
		Debug.Log(_config["configNode1"].ToObject<ConfigNodeInt>().data);
		Debug.Log(_config["configNode2"].ToObject<ConfigNodeList>().items[0].name);

		// API Example
		Config_Init();
		Config_Add<ConfigNodeInt>("configNode1");
		var myConfigNode = Config_GetNode<ConfigNodeInt>();
		Debug.Log(myConfigNode.data);
		var myConfigNodeNew = Config_GetNode<ConfigNodeInt>();
		Debug.Log(myConfigNodeNew.data);
		Debug.Log(myConfigNode == myConfigNodeNew);

		var jsonList = 
			"[{\"type\":\"weapon\", \"name\": \"firstItem\", \"cost\": \"100\", \"damage\": \"200\"}]";
		_itemList = JsonConvert.DeserializeObject<List<JObject>>(jsonList);

		// Test
		Debug.Log("ITEMS:");
		Debug.Log(_itemList.Count);
		Debug.Log(_itemList[0].ToObject<BaseItem>().name);
		Debug.Log(_itemList[0].ToObject<WeaponItem>().damage);

		// API Example
		Inv_Init();
		var item = Inv_GetItem("firstItem");
		Debug.Log(item.type);
		GetItem0(item);
		GetItem1(item);
	}

	void GetItem0(BaseItem item) {
		var weaponItem = Inv_GetItemAs<WeaponItem>(item);
		Debug.Log(weaponItem.damage);
	}

	void GetItem1(BaseItem item) {
		var weaponItemNew = Inv_GetItemAs<WeaponItem>(item);
		Debug.Log(weaponItemNew.damage);
	}

	void Config_Init() {
		_configNames = new Dictionary<Type, string>();
		_configCache = new Dictionary<Type, object>();
	}

	void Config_Add<T>(string path) {
		_configNames.Add(typeof(T), path);
	}

	T Config_GetNode<T>() {
		var type = typeof(T);
		if( _configCache.ContainsKey(type) ) {
			return (T)_configCache[type];
		} else {
			var obj = _config[_configNames[type]].ToObject<T>();
			_configCache.Add(type, obj);
			return obj;
		}
	}

	void Inv_Init() {
		_itemBases = new List<BaseItem>();
		_itemBinds = new Dictionary<BaseItem, JObject>();
		_itemCache = new Dictionary<BaseItem, object>();
		for( int i = 0; i < _itemList.Count; i++ ) {
			var baseItem = _itemList[i].ToObject<BaseItem>();
			_itemBases.Add(baseItem);
			_itemBinds.Add(baseItem, _itemList[i]);
		}	
	}

	BaseItem Inv_GetItem(string name) {
		for( int i = 0; i < _itemBases.Count; i++) {
			if( _itemBases[i].name == name ) {
				return _itemBases[i];
			}
		}
		return null;
	}

	T Inv_GetItemAs<T>(BaseItem item) {
		if( _itemBinds.ContainsKey(item) ) {
			if( _itemCache.ContainsKey(item) ) {
				return (T)_itemCache[item];
			} else {
				var obj = _itemBinds[item].ToObject<T>();
				_itemCache.Add(item, obj);
				return obj;
			}
		}

		return default(T);
	}
}
