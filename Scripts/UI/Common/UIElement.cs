using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.UI.Common {

	/// <summary>
	/// UIElement is a set of canvas elements with ability to show/hide. 
	/// If your element contains buttons or other interactable element, CanvasGroup is required.
	/// </summary>
	[AddComponentMenu("UDBase/UI/Element")]
	public class UIElement : MonoBehaviour {
		internal static HashSet<UIElement> Instances = new HashSet<UIElement>();

		/// <summary>
		/// UI Element lifetime state
		/// </summary>
		public enum UIElementState {

			/// <summary>
			/// None
			/// </summary>
			None,

			/// <summary>
			/// Starts to shown
			/// </summary>
			Showing,

			/// <summary>
			/// Fully shown
			/// </summary>
			Shown,

			/// <summary>
			/// Starts to hide
			/// </summary>
			Hiding,

			/// <summary>
			/// Fully hidden
			/// </summary>
			Hidden
		}

		/// <summary>
		/// Needs to show element when it is instantiated?
		/// </summary>
		[Tooltip("Needs to show element when it is instantiated?")]
		public bool AutoShow = true;

		/// <summary>
		/// Needs to set element interactable when it is firstly presented?
		/// </summary>
		[Tooltip("Needs to set element interactable when it is firstly presented?")]
		public bool InitialActive  = true;

		/// <summary>
		/// Needs to disable element when it is hidden?
		/// </summary>
		[Tooltip("Needs to disable element when it is hidden?")]
		public bool DisableOnHide = true;

		/// <summary>
		/// If set, animation retrieved only at first time (usuful if you don't change it at runtime)
		/// </summary>
		[Tooltip("If set, animation retrieved only at first time (usuful if you don't change it at runtime)")]
		public bool CacheAnimation = true;

		/// <summary>
		/// If checked, Childs will start to show after parent element is shown
		/// and all Childs will be hidden before parent element start to hide
		/// </summary>
		[Tooltip(
			@"If checked, Childs will start to show after parent element is shown
			and all Childs will be hidden before parent element start to hide")]
		public bool Ordered;

		/// <summary>
		/// Optional, you can set it to get ability to interact with all elements with given group
		/// </summary>
		[Tooltip("Optional, you can set it to get ability to interact with all elements with given group")]
		public string Group;

		/// <summary>
		/// Child elements
		/// </summary>
		[Tooltip("Child elements")]
		public List<UIElement> Childs = new List<UIElement>();

		/// <summary>
		/// Has al least one child?
		/// </summary>
		public bool HasChilds {
			get {
				return Childs.Count > 0;
			}
		}

		/// <summary>
		/// Has a parent element?
		/// </summary>
		public bool HasParent {
			get {
				return _parent;
			}
		}

		/// <summary>
		/// Current lifetime state
		/// </summary>
		/// <value>The state.</value>
		public UIElementState State { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether this element is interactable
		/// </summary>
		public bool IsInteractable {
			get {
				return _isInteractable;
			}
			set {
				_isInteractable = value;
				UpdateInteractable(_isInteractable);
				if( HasChilds ) {
					for( int i = 0; i < Childs.Count; i++ ) {
						Childs[i].IsInteractable = _isInteractable;
					}
				}
			}
		}

		IShowAnimation  _showAnimation  = null;
		IHideAnimation  _hideAnimation  = null;
		IClearAnimation _clearAnimation = null;
		bool            _isInteractable = false;
		bool            _groupChecked   = false;
		CanvasGroup     _group          = null;
		UIElement       _parent         = null;

		IEvent _events;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(IEvent events) {
			_events = events;
			if( CacheAnimation ) {
				AssingAnimation(true);
			}
			if( HasChilds ) {
				for( int i = 0; i < Childs.Count; i++ ) {
					Childs[i].SetParent(this);
				}
			}
		}

		bool IsChild(UIElement element) {
			return Childs.Contains(element);
		}

		bool IsAllChildsHidden() {
			for( int i = 0; i < Childs.Count; i++ ) {
				if( Childs[i].State != UIElementState.Hidden ) {
					return false;
				}
			}
			return true;
		}

		void OnElementHidden(UI_ElementHidden e) {
			if( Ordered && IsChild(e.Element) && IsAllChildsHidden() ) {
				PerformHide();
			}
		}

		void SetParent(UIElement parent) {
			_parent = parent;
		}

		void OnEnable() {
			Instances.Add(this);
			_events?.Subscribe<UI_ElementHidden>(this, OnElementHidden);
		}

		void OnDisable() {
			Instances.Remove(this);
			_events?.Unsubscribe<UI_ElementHidden>(OnElementHidden);
		}

		void Start() {
			if( !HasParent ) {
				IsInteractable = InitialActive;
				if( AutoShow ) {
					Show();
				} else {
					State = UIElementState.Hidden;
				}
			}
		}

		void AssingAnimation(bool firstTime = false) {
			if( firstTime || !CacheAnimation ) {
				_showAnimation = GetComponent<IShowAnimation>();
				_hideAnimation = GetComponent<IHideAnimation>();
				_clearAnimation = GetComponent<IClearAnimation>();
			}
		}

		bool CanShow() {
			return 
				(State != UIElementState.Showing) &&
				(State != UIElementState.Shown);
		}

		void SetHidden() {
			if( _clearAnimation != null ) {
				_clearAnimation.Clear();
			}
			if( HasChilds ) {
				for( int i = 0; i < Childs.Count; i++ ) {
					Childs[i].SetHidden();
				}
			}
		}

		void SetShown() {
			if( _clearAnimation != null ) {
				_clearAnimation.Clear();
			}
			if( HasChilds ) {
				for( int i = 0; i < Childs.Count; i++ ) {
					Childs[i].SetShown();
				}
			}
		}

		/// <summary>
		/// Show element with assigned animations
		/// </summary>
		[ContextMenu("Show")]
		public void Show() {
			State = UIElementState.Showing;
			gameObject.SetActive(true);
			AssingAnimation();
			SetHidden();
			if( _showAnimation != null ) {
				_showAnimation.Show(this, () => OnShowComplete());
			} else {
				OnShowComplete();
			}
			if( HasChilds ) {
				if( !Ordered ) {
					for( int i = 0; i < Childs.Count; i++ ) {
						Childs[i].Show();
					}
				}
			}
		}

		void OnShowComplete() {
			State = UIElementState.Shown;
			_events.Fire(new UI_ElementShown(this));
			if( Ordered ) {
				for( int i = 0; i < Childs.Count; i++ ) {
					Childs[i].Show();
				}
			}
		}

		bool CanHide() {
			return 
				(State != UIElementState.Hiding) &&
				(State != UIElementState.Hidden);
		}

		/// <summary>
		/// Hide element with assigned animations
		/// </summary>
		[ContextMenu("Hide")]
		public void Hide() {
			State = UIElementState.Hiding;
			AssingAnimation();
			SetShown();
			if( !Ordered ) {
				PerformHide();
			}
			if( HasChilds ) {
				for( int i = 0; i < Childs.Count; i++ ) {
					Childs[i].Hide();
				}
			} else {
				PerformHide();
			}
		}

		void PerformHide() {
			AssingAnimation();
			if( _hideAnimation != null ) {
				_hideAnimation.Hide(this, () => OnHideComplete());
			} else {
				OnHideComplete();
			}
		}

		void OnHideComplete() {
			if( DisableOnHide ) {
				gameObject.SetActive(false);
			}
			State = UIElementState.Hidden;
			_events.Fire(new UI_ElementHidden(this));
		}

		/// <summary>
		/// Enable interactions with this element
		/// </summary>
		[ContextMenu("Activate")]
		public void Activate() {
			IsInteractable = true;
		}

		/// <summary>
		/// Disable interactions with this element
		/// </summary>
		[ContextMenu("Deactivate")]
		public void Deactivate() {
			IsInteractable = false;
		}

		void UpdateInteractable(bool isInteractable) {
			if( !_groupChecked ) {
				_group = GetComponent<CanvasGroup>();
				_groupChecked = true;
			}
			if( _group ) {
				_group.interactable = isInteractable;
			}
		}

		/// <summary>
		/// Shows element, if it is hidden and opposite
		/// </summary>
		public void Switch() {
			switch ( State ) {
				case UIElementState.None:
				case UIElementState.Shown:
					Hide();
					break;
				
				case UIElementState.Hidden:
					Show();
					break;
			}
		}
	}
}
