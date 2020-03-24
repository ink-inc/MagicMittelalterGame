using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthbar : MonoBehaviour
{

    public Image healthbarBack;
    public Image healthbarFront;
    public PlayerProperties prop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SetHealth(float currentHealth)  //Adjusts red health bar to current health 
    {
        float maxHealth = prop.GetMaxHealth();
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        float maxHealthPercentage = maxHealth / 100;
        float healthbarPercentageFilled = currentHealth / maxHealthPercentage;
        healthbarFront.rectTransform.sizeDelta = new Vector2(healthbarPercentageFilled * 2, 20);  //healthbarSize currently 200 -> 2px equals 1% health
    }
}
