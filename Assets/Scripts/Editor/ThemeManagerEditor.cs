using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeManager))]
    public class ThemeManagerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            /*ThemeManager themeManager = (ThemeManager)target;
            GUILayout.Space(50);
            GUILayout.Label("Select a Theme Index to apply");
            themeManager.indexToApply = int.Parse(EditorGUILayout.TextField(themeManager.indexToApply.ToString()));

            if (GUILayout.Button("Apply Theme"))
            {
                ThemeManager.ApplyTheme(themeManager.indexToApply);
            }
            this.Repaint();*/
        }
    }
}