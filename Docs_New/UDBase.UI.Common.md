## `ActionButton`

Base class for buttons which perform specific action
```csharp
public abstract class UDBase.UI.Common.ActionButton
    : MonoBehaviour

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Init() | Must be called in Start callback to set callback and initialy update state | 
| `Boolean` | IsInteractable() | Is should button currently be interactable? | 
| `Boolean` | IsVisible() | Is should button currently visible? | 
| `void` | OnClick() | Concrete action to perform on click | 
| `void` | UpdateState() | Update button visibility and interactable state | 


## `CustomOverlayFactory`

```csharp
public class UDBase.UI.Common.CustomOverlayFactory
    : IFactory, IFactory<GameObject, UIOverlay>

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `UIOverlay` | Create(`GameObject` prefab) |  | 


## `IClearAnimation`

UI elemenent animation clearing is required when animation has state and it needs to be reset when stopping
```csharp
public interface UDBase.UI.Common.IClearAnimation

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() | Clear animation state | 


## `IHideAnimation`

Animation when element hiding
```csharp
public interface UDBase.UI.Common.IHideAnimation

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Hide(`UIElement` element, `Action` action) | Hide the specified element with callback | 
| `void` | SetHidden() | Set element hide | 


## `IShowAnimation`

Animation, when element showing
```csharp
public interface UDBase.UI.Common.IShowAnimation

```

Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | SetShown() | Set state to shown | 
| `void` | Show(`UIElement` element, `Action` action) | Show the specified element with action | 


## `OverlayFactory`

```csharp
public class UDBase.UI.Common.OverlayFactory
    : Factory<GameObject, UIOverlay>, IFactory, IPlaceholderFactory, IFactory<GameObject, UIOverlay>, IValidatable

```

## `UI_ElementHidden`

Event which fired when element is hidden
```csharp
public struct UDBase.UI.Common.UI_ElementHidden

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `UIElement` | Element |  | 


## `UI_ElementShown`

Event which fired when element is shown
```csharp
public struct UDBase.UI.Common.UI_ElementShown

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `UIElement` | Element |  | 


## `UIAnimationController`

Controller to play animation combinations on UI element
```csharp
public class UDBase.UI.Common.UIAnimationController
    : MonoBehaviour, IClearAnimation, IHideAnimation, IShowAnimation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<UIShowHideAnimation>` | HideSteps | All hide animations | 
| `List<UIShowHideAnimation>` | ShowSteps | All show animations | 
| `Boolean` | StepByStep | Shoud animations played step by step? | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() |  | 
| `void` | Hide(`UIElement` element, `Action` action) |  | 
| `void` | SetHidden() |  | 
| `void` | SetShown() |  | 
| `void` | Show(`UIElement` element, `Action` action) |  | 


## `UICanvas`

Canvas to show overlays
```csharp
public class UDBase.UI.Common.UICanvas
    : MonoBehaviour

```

## `UIElement`

UIElement is a set of canvas elements with ability to show/hide.  If your element contains buttons or other interactable element, CanvasGroup is required.
```csharp
public class UDBase.UI.Common.UIElement
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | AutoShow | Needs to show element when it is instantiated? | 
| `Boolean` | CacheAnimation | If set, animation retrieved only at first time (usuful if you don't change it at runtime) | 
| `List<UIElement>` | Childs | Child elements | 
| `Boolean` | DisableOnHide | Needs to disable element when it is hidden? | 
| `String` | Group | Optional, you can set it to get ability to interact with all elements with given group | 
| `Boolean` | InitialActive | Needs to set element interactable when it is firstly presented? | 
| `Boolean` | Ordered | If checked, Childs will start to show after parent element is shown  and all Childs will be hidden before parent element start to hide | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | HasChilds | Has al least one child? | 
| `Boolean` | HasParent | Has a parent element? | 
| `Boolean` | IsInteractable | Gets or sets a value indicating whether this element is interactable | 
| `UIElementState` | State | Current lifetime state | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Activate() | Enable interactions with this element | 
| `void` | Deactivate() | Disable interactions with this element | 
| `void` | Hide() | Hide element with assigned animations | 
| `void` | Init(`IEvent` events) | Init with dependencies | 
| `void` | Show() | Show element with assigned animations | 


Static Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `List<UIElement>` | Instances |  | 


## `UIFadeAnimation`

Set element visibility from transparent to solid when shown
```csharp
public class UDBase.UI.Common.UIFadeAnimation
    : UIShowHideAnimation, IClearAnimation, IHideAnimation, IShowAnimation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Duration | Duration of both animations | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() |  | 
| `void` | Hide(`UIElement` element, `Action` action) |  | 
| `void` | SetHidden() |  | 
| `void` | SetShown() |  | 
| `void` | Show(`UIElement` element, `Action` action) |  | 


## `UIManager`

UI system is based on Unity UI and provides you methods of interacting with grouped interface elements which can contain animations.  With UIManager you can show overlays and dialogs and also switch elements visibility: all or by its group.  You can specify key command to Show/Hide elements using ShowHideToggle field.  UIManager is created by request if it is not exist on scene before.  To show overlay/dialog you need to add* UICanvas* component to your canvas, that will show that elements, or assign it directly.
```csharp
public class UDBase.UI.Common.UIManager
    : MonoBehaviour

```

Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Int32` | OverlayDepth | How many overlays is shown? | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | CallOverlayCallback(`Boolean` result) |  | 
| `void` | FreeOverlay(`Boolean` result) |  | 
| `void` | Hide(`String` group) | Hide UI elements of the specified group | 
| `void` | HideAll() | Hide all UI elements | 
| `void` | Init(`Settings` settings, `OverlayFactory` overlayFactory, `List<IContent>` loaders, `ILog` log) | Init with dependencies | 
| `void` | Show(`String` group) | Show UI elements of the specified group | 
| `void` | ShowAll() | Shows all UI elements | 
| `void` | ShowDialog(`ContentId` content, `Action` onOk, `Action` onCancel) | Shows the dialog with positive and negative callbacks | 
| `void` | ShowDialog(`ContentId` content, `Action<Boolean>` callback) | Shows the dialog with positive and negative callbacks | 
| `void` | ShowDialog(`GameObject` prefab, `Action` onOk, `Action` onCancel) | Shows the dialog with positive and negative callbacks | 
| `void` | ShowDialog(`GameObject` prefab, `Action<Boolean>` callback) | Shows the dialog with positive and negative callbacks | 
| `void` | ShowOverlay(`ContentId` content, `Action` callback) | Shows the overlay with closing callback | 
| `void` | ShowOverlay(`GameObject` prefab, `Action` callback) | Shows the overlay with closing callback | 


## `UIMoveAnimation`

Move element with given offset when shown
```csharp
public class UDBase.UI.Common.UIMoveAnimation
    : UIShowHideAnimation, IClearAnimation, IHideAnimation, IShowAnimation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Duration | Duration of both animations | 
| `Vector3` | Offset | Offset to move | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() |  | 
| `void` | Hide(`UIElement` element, `Action` action) |  | 
| `void` | SetHidden() |  | 
| `void` | SetShown() |  | 
| `void` | Show(`UIElement` element, `Action` action) |  | 


## `UIOverlay`

UIOverlay is a component which shows overlays and dialogs to user:  it can be closed with boolean argument and you can pass callback which would be executed when wanted result is happen.  When overlay is shown, all background elements become non-interactable and made interactable back after overlay is hidden.  Overlay can be shown over another overlay.
```csharp
public class UDBase.UI.Common.UIOverlay
    : MonoBehaviour

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `OverlayHideMode` | HideMode | How overlay needs to closed? | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Close() | Close this overlay with negative decision | 
| `void` | Close(`Boolean` result) | Close this overlay with negative decision | 
| `void` | Init(`IEvent` events, `UIManager` manager) | Init with dependencies | 
| `void` | Show() | Show this overlay | 


## `UIScaleAnimation`

Scale element from zero to original when shown
```csharp
public class UDBase.UI.Common.UIScaleAnimation
    : UIShowHideAnimation, IClearAnimation, IHideAnimation, IShowAnimation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `Single` | Duration | Duration of both animations | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() |  | 
| `void` | Hide(`UIElement` element, `Action` action) |  | 
| `void` | SetHidden() |  | 
| `void` | SetShown() |  | 
| `void` | Show(`UIElement` element, `Action` action) |  | 


## `UIShowHideAnimation`

Base class for full-cycle animations
```csharp
public abstract class UDBase.UI.Common.UIShowHideAnimation
    : MonoBehaviour, IClearAnimation, IHideAnimation, IShowAnimation

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `AnimationDirection` | Direction | Desired animation direction | 


Properties

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | HasHideAnimation | Heeds to hide animation? | 
| `Boolean` | HasShowAnimation | Needs to show animation? | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `void` | Clear() |  | 
| `void` | Hide(`UIElement` element, `Action` action) |  | 
| `void` | SetHidden() |  | 
| `void` | SetShown() |  | 
| `void` | Show(`UIElement` element, `Action` action) |  | 


## `UIStateButton`

Button to simply change state of UI element
```csharp
public class UDBase.UI.Common.UIStateButton
    : ActionButton

```

Fields

| Type | Name | Summary | 
| --- | --- | --- | 
| `UIElement` | Element | Element, which state is controlled | 


Methods

| Type | Name | Summary | 
| --- | --- | --- | 
| `Boolean` | IsInteractable() |  | 
| `Boolean` | IsVisible() |  | 
| `void` | OnClick() |  | 


