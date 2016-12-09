# Inventory

**Inventory** is an extendable controller to define your item structures which allows you to change it at runtime. Also, you can add your custom items and customize item transitions.   

## Basics

Inventory system is based on:

- **InventoryItem** - item state (item name, type and any of your custom data)
- **InventoryPack** - set of identical items (like resources, coins or something like that)
-  **ItemHolder** - matter that contains items and packs (player, NPC, etc.)
- Items and packs can be added/removed to/from holders. 

## Logics

First, you need to specify item structure in config:

```
"inventory_source":
	{
		"items": 
		[
			// Your items definition (name/type)
			{"name": "trash", "type": "common_item"},
			{"name": "sword", "type": "weapon_item"},
			{"name": "armor", "type": "armor_item"}
		],
		"packs":
		[
			// Your packs definitions (only name)
			{"name": "money"}
		],
		// Holders definition:
		"holders":
		[
			{
				"name": "player",
				// If you need to add initial items and packs, you can describe it
				"items": 
				[
					"trash"
				],
				"packs": 
				[
					{"name": "money", "count": 100}
				]
			}		
		]
	}
```

Inventory required **Config** and **Save** controllers setup (names can be changed):

```
config.AddNode<ItemSourceConfigNode>("inventory_source");
save.AddNode<InventorySaveNode>("inventory");
```

After it you need to create controller:

```
var inventory = new BasicInventory(autoSave);
```

With optional **autoSave** argument you can select save mode - after each change or manually (with *Inventory.SaveChanges()* call).

If you use Scheme with this controllers, you can work with Inventory:

- Get and change item packs (*Inventory.GetPackCount()/AddToPack()/RemoveFromPack()* methods)
- Add/remove and modify items (*AddItem(), RemoveItem()*, etc.)

For example, you can give "player" holder some "trash":

```
Inventory.AddItem("player", "trash");
```
After application restart your player will have it already.

## Transitions

**ITransitionHelper** - interface that defines how items can be moved between item holders (send, buy, sell, etc.).

Now there are two helpers:

- **BasicTransitionHelper** - any item can be transferred to another item holder without settings;
- **TradeTransitionHelper** - item can be transferred if another item holder contains enough "resources" to pay for it;

You can use this versions or create your own implementation and assign it to **BasicInventory** controller:

```
var transition = new TradeTransitionHelper("money", ItemHelper.GetPriceSelector);
var inventory = new BasicInventory(transition, autoSave);
```

In case of TradeTransitionHelper, "money" is a pack name to store your resources that would be paid for item and ItemHelper.GetPriceSelector - your custom function that returns price of specific item. That function may look like this:

```
public static class ItemHelper {
	public static int GetPriceSelector(InventoryItem item) {
		return GetItemPrice(item.Type, item.Name);
	}

	static int GetItemPrice(string type, string name) {
		switch( type ) {
			case "trash": return 5;
			case "gold": return 1000;
			case "silver": return 500;
		}
		return 0;
	}
}
```

## UI

Several components are used now for show and control items:

- **ItemPackView** - component that shows pack value for specific holder;
- **HolderItemsView** - component to create ItemView collection for specific holder and initialize it;
- **ItemView** - component that shows item info;
- **ItemControl** - component that executes some actions on items, based on ItemView (SendItemControl can be used to send items between holders);

This components can be simply extended for your purposes.

## Customization

You can store some state in inventory items (values, that can be changed in item lifetime). It can be durability, upgrade level, effects and so on. To use it you need to define your own class, based on InventoryItem and override two methods:

```
public class CustomItem:InventoryItem {
	// Your custom data
	[fsProperty("durability")]
	public int Durability = 0;

	public CustomItem() {}

	public CustomItem(string name, string type, int durability):base(name, type) {
		Durability = durability;
	}

	// Method to create new item and setup your data
	public override void Init() {
		Durability = 100;
	}

	// Method to create new item based on existed item
	public override InventoryItem Clone() {
		return new ArmorItem(Name, Type, Durability);
	}
}

```

And add it to inventory:

```
inventory.AddType<CustomItem>("custom_type");
```

After it, any item with type "custom_type" uses *CustomItem* instance to save its state.

Note that the best way to store persistant item info is **Config** controller. Do not save things like cost, damage and other values that does not change in item state, it is excessively and you can't change it after save is done fist time. You can store it in list in config and get by item name.

For more examples look at [Example Project](https://github.com/KonH/UDBaseExample).