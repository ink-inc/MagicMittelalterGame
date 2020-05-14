using UnityEngine;
using UnityEngine.UI;
using Util;

public class PlayerHealthbar : MonoBehaviour
{

    public Float health;
    public Float maxHealth;

    public Image healthbarBack;
    public Image healthbarFront;
    public Text healthbarText;

    private long _lasthitTime;

    public void Update()
    {
        //if (gameObject.activeSelf == false) return;

        //long currentTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        //if (currentTime - _lasthitTime > 10000) gameObject.SetActive(false);
    }

    public void Refresh()  //Adjusts red health bar to current health
    {
        _lasthitTime = System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        gameObject.SetActive(true);
        var maxHealthVal = maxHealth.Value;
        var healthVal = health.Value;

        healthbarText.text = $"{healthVal:N0} / {maxHealthVal:N0}";

        float maxHealthPercentage = maxHealthVal / 100;
        float healthbarPercentageFilled = healthVal / maxHealthPercentage;
        float absoluteValue = healthbarPercentageFilled * (healthbarBack.rectTransform.sizeDelta.x / 100); //Calculation: Percentage * (width of parent / 100) -> width for child
        healthbarFront.rectTransform.sizeDelta = new Vector2(absoluteValue, 20);

    }

    public void OnChange(Float f)
    {
        Refresh();
    }

    public void OnEnable()
    {
        health.AddListener(OnChange);
        maxHealth.AddListener(OnChange);
        Refresh();
    }

    public void OnDisable()
    {
        health.RemoveListener(OnChange);
        maxHealth.RemoveListener(OnChange);
    }
}