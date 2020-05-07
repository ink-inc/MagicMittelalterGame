using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Theme
{
    [AddComponentMenu("Theme/Target/ImageTarget")]
    public class ThemeTarget_Image : ThemeTarget
    {
        public override void Refresh()
        {
            Image image = GetComponent<Image>();
            image.color = GetColor();
        }
    }
}