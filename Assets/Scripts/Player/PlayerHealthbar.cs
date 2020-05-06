using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{
    public Image healthbarBack;
    public Image healthbarFront;

    public void SetHealth(float currentHealth, float maxHealth)  //Adjusts red health bar to current health
    {
        gameObject.SetActive(true);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        float maxHealthPercentage = maxHealth / 100;
        float healthbarPercentageFilled = currentHealth / maxHealthPercentage;
        float absoluteValue = healthbarPercentageFilled * (healthbarBack.rectTransform.sizeDelta.x / 100); //Calculation: Percentage * (width of parent / 100) -> width for child
        healthbarFront.rectTransform.sizeDelta = new Vector2(absoluteValue, 20);
    }
}