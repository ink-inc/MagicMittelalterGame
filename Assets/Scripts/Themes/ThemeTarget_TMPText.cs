using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Theme
{
    [AddComponentMenu("Theme/Target/TMPTextTarget")]
    public class ThemeTarget_TMPText : ThemeTarget
    {
        public override void Refresh()
        {
            TextMeshProUGUI text = GetComponent<TextMeshProUGUI>();
            text.color = GetColor();
        }
    }
}