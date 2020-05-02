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

            ThemeManager themeManager = (ThemeManager)target;
            GUILayout.Space(50);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Theme to apply");
            themeManager.indexToApply = EditorGUILayout.Popup(themeManager.indexToApply, themeManager.GetSelectableThemes());
            if (GUILayout.Button("Apply Theme"))
            {
                if (themeManager.indexToApply < 0 || themeManager.indexToApply >= themeManager.selectableThemes.Length)
                {
                    themeManager.indexToApply = 0;
                    return;
                }
                ThemeManager.ApplyTheme(themeManager.indexToApply);
            }

            GUILayout.EndHorizontal();
        }
    }
}