using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Theme
{
    public enum ButtonType
    { Button, Toggle }

    [AddComponentMenu("Theme/Target/ButtonTarget")]
    public class ThemeTarget_Button : ThemeTarget
    {
        public ButtonType type = ButtonType.Button;

        [HideInInspector]
        public int arrayIndex_highlighted = 0;

        [HideInInspector]
        public int arrayIndex_pressed = 0;

        [HideInInspector]
        public int arrayIndex_selected = 0;

        public override void Refresh()
        {
            Selectable button = GetComponent<Button>();
            if (type == ButtonType.Toggle)
                button = GetComponent<Toggle>();
            if (button == null)
            {
                Logger.logError("Button Target on " + gameObject.name + " could not find the Button!");
                return;
            }
            var colors = button.colors;
            colors.normalColor = GetColor(ThemeManager.GetName(arrayIndex));
            colors.highlightedColor = GetColor(ThemeManager.GetName(arrayIndex_highlighted));
            colors.pressedColor = GetColor(ThemeManager.GetName(arrayIndex_pressed));
            colors.selectedColor = GetColor(ThemeManager.GetName(arrayIndex_selected));
            button.colors = colors;
        }
    }
}