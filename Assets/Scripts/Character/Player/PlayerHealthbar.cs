using UnityEngine;
using UnityEngine.UI;
using Util;

namespace Character.Player
{
    public class PlayerHealthbar : MonoBehaviour
    {

        public Float health;
        public Float maxHealth;
    
        public Image healthbarBack;
        public Image healthbarFront;
        public Text healthbarText;

        public void Refresh()  //Adjusts red health bar to current health
        {
            var maxHealthVal = maxHealth.Value;
            var healthVal = health.Value;

            healthbarText.text = $"{healthVal:N0} / {maxHealthVal:N0}";
        
            float maxHealthPercentage = maxHealthVal / 100;
            float healthbarPercentageFilled = healthVal / maxHealthPercentage;
            float absoluteValue = healthbarPercentageFilled * (healthbarBack.rectTransform.sizeDelta.x / 100); //Calculation: Percentage * (width of parent / 100) -> width for child
            healthbarFront.rectTransform.sizeDelta = new Vector2(absoluteValue, 20);
        }

        private void OnChange(Float f)
        {
            Refresh();
        }

        private void OnEnable()
        {
            health.AddListener(OnChange);
            maxHealth.AddListener(OnChange);
            Refresh();
        }

        private void OnDisable()
        {
            health.RemoveListener(OnChange);
            maxHealth.RemoveListener(OnChange);
        }
    }
}