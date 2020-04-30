using System.Collections.Generic;
using Status;
using UnityEngine;
using UnityEngine.UI;

namespace HUD
{
    public class StatusEffectHUD : MonoBehaviour
    {
        public GameObject effectHUDElementPrefab;

        private readonly List<EffectHUDElement> _hudElements = new List<EffectHUDElement>();

        public void AddEffect(StatusEffectInstance instance)
        {
            var go = Instantiate(effectHUDElementPrefab, transform);
            var images = go.GetComponentsInChildren<Image>();
            var text = go.GetComponentInChildren<Text>();
            var element = new EffectHUDElement(instance, go, images[1], text);

            _hudElements.Add(element);
        }

        private void Update()
        {
            for (var i = _hudElements.Count - 1; i >= 0; i--)
            {
                var element = _hudElements[i];
                if (element.Effect.MarkedForRemoval)
                {
                    Destroy(element.GameObject);
                    _hudElements.RemoveAt(i);
                    continue;
                }

                element.GameObject.SetActive(element.Effect.Active);
                element.Image.sprite = element.Effect.GetHUDSprite();

                var text = element.Effect.GetHUDText();
                element.Text.text = text;
            }
        }

        private class EffectHUDElement
        {
            public readonly StatusEffectInstance Effect;
            public readonly GameObject GameObject;
            public readonly Image Image;
            public readonly Text Text;

            public EffectHUDElement(StatusEffectInstance effect, GameObject gameObject, Image image, Text text)
            {
                Effect = effect;
                GameObject = gameObject;
                Image = image;
                Text = text;
            }
        }
    }
}