using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Theme
{
    public abstract class ThemeTarget : MonoBehaviour
    {
        //[Header("Copy this value to 'Property Name'")]
        //public string copyName;

        [Space(30)]
        [HideInInspector]
        public string propertyName = "UI_background";

        private void OnEnable()
        {
            Refresh();
        }

        private void Awake()
        {
            Refresh();
        }

        public void SetPropertyName(string value)
        {
            propertyName = value;
        }

        public string GetPropertyName()
        {
            return propertyName;
        }

        public Color GetColor()
        {
            Logger.log("Getting color: " + GetPropertyName() + " from: " + gameObject.name);
            return ThemeManager.GetColorByName(GetPropertyName());
        }

        public Color GetColor(string name)
        {
            Logger.log("Getting color: " + name + " from: " + gameObject.name);
            return ThemeManager.GetColorByName(name);
        }

        public abstract void Refresh();
    }
}