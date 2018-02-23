﻿using UnityEngine;
using UDBase.UI.Common;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.Controllers.LocalizationSystem.UI {
	/// <summary>
	/// ActionButton to change current language of ILocalization component 
	/// </summary>
	[AddComponentMenu("UDBase/UI/Localization/SetLanguageButton")]
	public class SetLanguageButton : ActionButton {

		/// <summary>
		/// Language to set in ILocalization when clicked
		/// </summary>
		[Tooltip("Language to set in ILocalization when clicked")]
		public SystemLanguage Language;

		ILocalization _localization;
		IEvent        _events;

		/// <summary>
		/// Init with dependencies
		/// </summary>
		[Inject]
		public void Init(ILocalization localization, IEvent events) {
			_localization = localization;
			_events       = events;
			_events.Subscribe<LanguageChanged>(this, OnLanguageChanged);
		}

		void OnDestroy() {
			_events?.Unsubscribe<LanguageChanged>(OnLanguageChanged);
		}

		void OnLanguageChanged(LanguageChanged e) {
			UpdateState();
		}

		public override bool IsInteractable() => _localization.CurrentLanguage != Language;

		public override bool IsVisible() => true;

		public override void OnClick() => _localization.CurrentLanguage = Language;

	}
}
