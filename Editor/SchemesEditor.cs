using UnityEngine;
using UnityEditor;
using System;
using System.Collections;

namespace UDBase.Editor {
	public class SchemesEditor : EditorWindow {
		enum State {
			Start,
			NewSchemeScript,
			NewSchemeAsset
		}

		SchemesTool _st;
		SchemesTool st {
			get {
				if( _st == null ) {
					_st = new SchemesTool();
				}
				return _st;
			}
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

				case State.NewSchemeAsset: {
						DrawState_NewSchemeAsset();
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
					st.CreateDirectory(_newSchemeName);
					st.CreateSchemeScript(_newSchemeName);
					_state = State.NewSchemeAsset;
				}
			}
			GUILayout.EndVertical();
		}

		void DrawState_NewSchemeAsset() {
			GUILayout.BeginVertical();
			if( EditorApplication.isCompiling ) {
				GUILayout.Label("Wait for compilation...");
			} else if( GUILayout.Button("Create asset") ) {
				st.CreateAsset(_newSchemeName);
				_state = State.Start;
			}
			GUILayout.EndVertical();
		}
	}
}
