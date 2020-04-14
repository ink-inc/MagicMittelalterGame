using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Image healthbarBack;
    public Image healthbarFront;
    public Text healthbarText;
    public PlayerProperties prop;

    public void SetHealth(float currentHealth) //Adjusts red health bar to current health
    {
        float maxHealth = prop.maxHealth.Value;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        healthbarText.text = String.Format($"{currentHealth:N0} / {maxHealth:N0}");
        
        float maxHealthPercentage = maxHealth / 100;
        float healthbarPercentageFilled = currentHealth / maxHealthPercentage;
        float absoluteValue = healthbarPercentageFilled * (healthbarBack.rectTransform.sizeDelta.x / 100); //Calculation: Percentage * (width of parent / 100) -> width for child
        healthbarFront.rectTransform.sizeDelta = new Vector2(absoluteValue, 20);
    }

    public void Refresh()
    {
        SetHealth(prop.GetHealth());
    }
}