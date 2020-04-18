using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeTarget), true)]
    public class TargetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ThemeTarget script = (ThemeTarget)target;

            GUIContent arrayLabel = new GUIContent("Theme Component Name");

            script.arrayIndex = EditorGUILayout.Popup(arrayLabel, script.arrayIndex, ThemeManager.GetGroupNames());
        }
    }
}