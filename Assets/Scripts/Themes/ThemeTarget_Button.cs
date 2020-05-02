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
        [HideInInspector]
        public string propertyName_highlighted;

        [HideInInspector]
        public string propertyName_pressed;

        [HideInInspector]
        public string propertyName_selected;

        [HideInInspector]
        public string propertyName_disabled;

        public ButtonType type = ButtonType.Button;

        public void SetPropertyName(string value, int id)
        {
            switch (id)
            {
                case 1:
                    propertyName_highlighted = value;
                    break;

                case 2:
                    propertyName_pressed = value;
                    break;

                case 3:
                    propertyName_selected = value;
                    break;

                case 4:
                    propertyName_disabled = value;
                    break;

                default:
                    propertyName = value;
                    break;
            }
        }

        public string GetPropertyName(int id)
        {
            switch (id)
            {
                case 1:
                    return propertyName_highlighted;

                case 2:
                    return propertyName_pressed;

                case 3:
                    return propertyName_selected;

                case 4:
                    return propertyName_disabled;

                default:
                    return GetPropertyName();
            }
        }

        public override void Refresh()
        {
            Selectable[] buttons = GetComponents<Button>();
            for (int i = 0; i < buttons.Length; i++)
            {
                Selectable button = buttons[i];
                if (type == ButtonType.Toggle)
                    button = GetComponent<Toggle>();
                if (button == null)
                {
                    Logger.logError("Button Target on " + gameObject.name + " could not find the Button!");
                    return;
                }
                var colors = button.colors;
                colors.normalColor = GetColor(GetPropertyName(0));
                colors.highlightedColor = GetColor(GetPropertyName(1));
                colors.pressedColor = GetColor(GetPropertyName(2));
                colors.selectedColor = GetColor(GetPropertyName(3));
                colors.disabledColor = GetColor(GetPropertyName(4));
                button.colors = colors;
            }
        }
    }
}