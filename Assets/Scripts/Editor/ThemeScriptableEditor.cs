using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Theme
{
    [CustomEditor(typeof(ThemeScriptable))]
    public class ThemeScriptableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            ThemeScriptable script = (ThemeScriptable)target;

            List<string> strings = new List<string>();
            foreach (ThemeComponent tc in script.themeComponents)
            {
                strings.Add(tc.name);
            }
            script.availableGroups = strings.ToArray();
        }
    }
}