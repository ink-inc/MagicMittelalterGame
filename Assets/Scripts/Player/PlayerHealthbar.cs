using UnityEngine;
using UnityEngine.UI;
using Util;

public class PlayerHealthbar : MonoBehaviour
{

    public FloatVariable health;
    public FloatVariable maxHealth;
    
    public Image healthbarBack;
    public Image healthbarFront;
    public Text healthbarText;

    private void Update()  //Adjusts red health bar to current health
    {
        float maxHealthVal = maxHealth.Value;
        float healthVal = health.Value;

        healthbarText.text = $"{healthVal:N0} / {maxHealthVal:N0}";
        
        float maxHealthPercentage = maxHealthVal / 100;
        float healthbarPercentageFilled = healthVal / maxHealthPercentage;
        float absoluteValue = healthbarPercentageFilled * (healthbarBack.rectTransform.sizeDelta.x / 100); //Calculation: Percentage * (width of parent / 100) -> width for child
        healthbarFront.rectTransform.sizeDelta = new Vector2(absoluteValue, 20);
    }
}