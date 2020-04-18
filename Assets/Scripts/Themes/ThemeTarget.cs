using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public abstract class ThemeTarget : MonoBehaviour
    {
        [HideInInspector]
        public int arrayIndex = 0;

        private void Awake()
        {
            Refresh();
        }

        public string GetName()
        {
            return ThemeManager.GetName(arrayIndex);
        }

        public Color GetColor()
        {
            return ThemeManager.GetColorByName(name);
        }

        public Color GetColor(string name)
        {
            return ThemeManager.GetColorByName(name);
        }

        public abstract void Refresh();
    }
}