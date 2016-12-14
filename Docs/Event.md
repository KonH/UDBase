# Event

Events is a lightweight event system, based on System.Action. It does not use UnityEvent or native C# event/delegate way.

## Initialization

Just add **EventController** to your scheme:

```
AddController<Events>(new EventController());
```

## Subscribe

If your class needs to listen to some event use this syntax:

```
public class EventExample:MonoBehaviour {
	void OnEnable() {
		Events.Subscribe<TestEvent>(this, OnTestEvent);
	}
}
```

TestEvent is a type of event which is tracked.
And you need to implement your handler for this event:

```
void OnTestEvent(TestEvent e) {
	// your reaction to the event
}
```

## Broadcast

Event can be fired using **Fire** method:

```
Events.Fire(new TestEvent());
```

All event watchers give this event and can do what they need with it.

## Unsubscribe

You can unsubscribe from event if you don't need to track it yet:

```
void OnEnable() {
	Events.Unsubscribe<TestEvent>(OnTestEvent);
}
```

Unsubscribing is required for custom classes, but it is just recommended for **MonoBehaviour** classes, because before each event firing watchers checked for destroyed scripts and remove it.

## Custom events

You can use any class or scruct which contains your event related info in similar way.

## Debug
You can use custom window in **UDBase/Events/Debug Window** to overview all active events and its watchers.