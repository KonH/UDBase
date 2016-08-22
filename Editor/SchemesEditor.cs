using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

namespace UDBase.Editor {
	// TODO:
	// View, remove, switch schemes
	public class SchemesEditor : EditorWindow {
		enum State {
			Start,
			NewSchemeScript
		}

		State  _state         = State.Start;
		string _newSchemeName = "";

		void OnGUI() {
			DrawState(_state);
		}

		void DrawState(State state) {
			switch( state ) {
				case State.Start: {
					DrawState_Start();
				}
				break;

				case State.NewSchemeScript: {
						DrawState_NewSchemeScript();
					}
				break;
			}
		}

		void DrawState_Start() {
			GUILayout.BeginVertical();
			if( GUILayout.Button("Add new scheme") ) {
				_state = State.NewSchemeScript;
				_newSchemeName = "";
			}
			GUILayout.EndVertical();
		}

		void DrawState_NewSchemeScript() {
			GUILayout.BeginVertical();
			if( GUILayout.Button("Back") ) {
				_state = State.Start;
			}
			GUILayout.Label("Name:");
			_newSchemeName = GUILayout.TextArea(_newSchemeName);
			if( _newSchemeName.Length > 0) {
				if( GUILayout.Button("Create script") ) {
					SchemesTool.CreateSchemeScript(_newSchemeName);
					_state = State.Start;
				}
			}
			GUILayout.EndVertical();
		}
	}
}
