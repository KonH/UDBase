﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UDBase.Controllers.EventSystem;
using Zenject;

namespace UDBase.EditorTools {
	public class EventWindow : EditorWindow {
		readonly Dictionary<Type, bool> _folds = new Dictionary<Type, bool>();
		
		bool                           _ready;
		Dictionary<Type, List<object>> _handlers;
		Vector2                        _scrollPos = Vector2.zero;

		[InjectOptional]
		IEvent _events;

		void OnGUI() {
			_ready = UpdateState();
			DrawState();
		}

		bool UpdateState() {
			if( _events != null ) {
				var eventController = _events as EventController;
				if( eventController != null ) {
					_handlers = eventController.GetHandlers();
					return true;
				}
			}
			return false;
		}

		void DrawState() {
			if( !_ready ) {
				GUILayout.Label("EventSystem is not loaded");
				return;
			}
			if( _handlers.Count == 0 ) {
				GUILayout.Label("No events is subscribed");
				return;
			}
			_scrollPos = GUILayout.BeginScrollView(_scrollPos, GUILayout.MaxWidth(300));
			var handlerIter = _handlers.GetEnumerator();
			while( handlerIter.MoveNext() ) {
				var current = handlerIter.Current;
				if( DrawHeader(current.Key) ) {
					DrawHandlers(current.Value);
				}
			}
			GUILayout.EndScrollView();
		}

		bool DrawHeader(Type type) {
			bool fold;
			if( !_folds.TryGetValue(type, out fold) ) {
				_folds.Add(type, false);
			}
			fold = EditorGUILayout.Foldout(fold, type.Name);
			_folds[type] = fold;
			return fold;
		}

		void DrawHandlers(List<object> handlers) {
			EditorGUI.indentLevel++;
			for( int i = 0; i < handlers.Count; i++ ) {
				DrawHandler(handlers[i]);
			}
			EditorGUI.indentLevel--;
		}

		void DrawHandler(object obj) {
			var monoObj = obj as MonoBehaviour;
			if( monoObj ) {
				EditorGUILayout.ObjectField(monoObj, monoObj.GetType(), true);
			} else {
				EditorGUILayout.LabelField(obj.ToString());
			}

		}
	}
}
