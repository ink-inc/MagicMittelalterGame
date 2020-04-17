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

        private void Awake()
        {
            instance = this;
        }

        public static Color GetColorByName(string name)
        {
            return instance.currentTheme.GetColorByName(name);
        }

        public void forceApplyTheme()
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
                forceApplyTheme();
                oldTheme = currentTheme;
            }
        }
    }
}