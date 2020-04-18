using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Theme
{
    [AddComponentMenu("Theme/Target/ToggleTarget")]
    public class ThemeTarget_Toggle : ThemeTarget
    {
        public string nameHighlighted;
        public string namePressed;
        public string nameSelected;
        public DropDown dd;

        public override void Refresh()
        {
            Toggle toggle = GetComponent<Toggle>();
            if (toggle == null)
            {
                Logger.logError("Toggle Target on " + gameObject.name + " could not find the Toggle!");
                return;
            }
            var colors = toggle.colors;
            colors.normalColor = GetColor(GetName()); //TODO: Buttons funktionieren nicht.....
            colors.highlightedColor = GetColor(nameHighlighted);
            colors.pressedColor = GetColor(namePressed);
            colors.selectedColor = GetColor(nameSelected);
            toggle.colors = colors;
        }
    }
}