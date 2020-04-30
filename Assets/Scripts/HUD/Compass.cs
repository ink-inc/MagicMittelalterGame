using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class Compass : MonoBehaviour
    {
        public Text compassText;
        public RawImage compassImage;
        public Transform directionParent;

        private void FixedUpdate()
        {
            updateCompass();
        }

        private void updateCompass()
        {
            int degrees = (int)directionParent.rotation.eulerAngles.y;
            compassText.text = degrees.ToString();
            compassImage.uvRect = new Rect(directionParent.localEulerAngles.y / 360f + 0.25f, 0f, 0.5f, 0.5f);
        }
    }
}