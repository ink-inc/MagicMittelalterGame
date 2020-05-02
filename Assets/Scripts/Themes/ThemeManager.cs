using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public class ThemeManager : MonoBehaviour
    {
        public static ThemeManager instance;
        public ThemeScriptable currentTheme;

        public ThemeScriptable[] selectableThemes;

        [HideInInspector]
        public int indexToApply;

        private void Awake()
        {
            instance = this;
        }

        public static string GetPropertyName(int id)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetName(id);
        }

        public static int GetPropertyIndex(string name)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetPropertyIndex(name);
        }

        public static Color GetColorByName(string name)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetColorByName(name);
        }

        public static string[] GetGroupNames()
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            return instance.currentTheme.GetGroupNames();
        }

        public static void ApplyTheme(int index)
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<ThemeManager>();
            instance.currentTheme = instance.selectableThemes[index];
            instance.ForceApplyTheme();
        }

        public string[] GetSelectableThemes()
        {
            string[] themes = new string[selectableThemes.Length];
            for (int i = 0; i < themes.Length; i++)
            {
                themes[i] = selectableThemes[i].name;
            }
            return themes;
        }

        public void ForceApplyTheme()
        {
            ThemeTarget[] targets = FindObjectsOfType<ThemeTarget>();
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].Refresh();
            }
        }

        private ThemeScriptable oldTheme;

        private void Update()
        {
            if (oldTheme != currentTheme)
            {
                ForceApplyTheme();
                oldTheme = currentTheme;
            }
        }
    }
}