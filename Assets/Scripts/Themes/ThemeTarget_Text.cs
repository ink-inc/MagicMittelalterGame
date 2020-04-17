using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Theme
{
    [AddComponentMenu("Theme/Target/TextTarget")]
    public class ThemeTarget_Text : ThemeTarget
    {
        public override void Refresh()
        {
            Text text = GetComponent<Text>();
            text.color = GetColor();
        }
    }
}