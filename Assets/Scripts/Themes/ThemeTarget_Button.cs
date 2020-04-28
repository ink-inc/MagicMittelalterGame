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

        [SerializeField]
        public string propertyName_highlighted;

        [SerializeField]
        public string propertyName_pressed;

        [SerializeField]
        public string propertyName_selected;

        [SerializeField]
        public string propertyName_disabled;

        public string GetName(int id)
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
                    return GetName();
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
                colors.normalColor = GetColor(GetName(0));
                colors.highlightedColor = GetColor(GetName(1));
                colors.pressedColor = GetColor(GetName(2));
                colors.selectedColor = GetColor(GetName(3));
                colors.disabledColor = GetColor(GetName(4));
                button.colors = colors;
            }
        }
    }
}