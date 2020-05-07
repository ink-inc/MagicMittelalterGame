﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeTarget), true)]
    public class ThemeTargetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            ThemeTarget script = (ThemeTarget)target;
            GUIContent arrayLabel = new GUIContent("Theme Component Name");
            int index = EditorGUILayout.Popup(arrayLabel, ThemeManager.GetPropertyIndex(script.GetPropertyName()), ThemeManager.GetGroupNames());
            script.SetPropertyName(ThemeManager.GetPropertyName(index));

            EditorGUILayout.BeginHorizontal(EditorStyles.helpBox);
            GUILayout.Label("Color preview:");
            EditorGUILayout.ColorField(ThemeManager.GetColorByName(ThemeManager.GetPropertyName(index)));
            EditorGUILayout.EndHorizontal();

            base.OnInspectorGUI();
        }
    }
}