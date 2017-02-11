# UI
UI system is based on Unity UI and provides you methods of interacting with grouped interface elements which can contain animations.

## UIElement

**UIElement** is a set of canvas elements with ability to show/hide. If your element contains buttons or other interactable element, *CanvasGroup* is required.

**UIElement** can contain **Childs**, which are a collection of another UIElements.
If **Ordered** is checked, Childs will start to show after parent element is shown and all Childs will be hidden before parent element start to hide.

**AutoShow** - needs to show element when it is instantiated or scene is loaded.

**InitialActive** - needs to set element interactable when it is firstly presented.

**DisableOnHide** - needs to disable element when it is hidden.

Optionally, you can set **Group** to element to get ability to interact with all elements with given group.

## Animations

On **UIElement** you can add animation which is played on element shown/hiding.

Included animations (using DOTween):

- *UIFadeAnimation* (change CanvasGroup alpha)
- *UIMoveAnimation* (move element by offset)
- *UIScaleAnimation* (scale element from zero)

To make custom animations you can use *IShowAnimation*, *IHideAnimation*, *IClearAnimation* interfaces or *UIShowHideAnimation* class.
Now animations are limited: you can't assign more than one animation to one UIElement.

## UIOverlay

**UIOverlay** is a component which shows overlays and dialogs to user: it can be closed with boolean argument and you can pass callback which would be executed when wanted result is happen.
When overlay is shown, all background elements become non-interactable and made interactable back after overlay is hidden.
Overlay can be shown over another overlay.

## UIManager

With **UIManager** you can show overlays (**ShowOverlay**) and dialogs (**ShowDialog**) and also switch elements visibility: all (**ShowAll**/**HideAll**) or by its group (**Show**/**Hide**). You can specify key command to Show/Hide elements using **ShowHideToggle** field.
UIManager is created by request if it is not exist on scene before.


To show overlay/dialog you need to add *UICanvas* component to your canvas, that will show that elements, or assign it directly.