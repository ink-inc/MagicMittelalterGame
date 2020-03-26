using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    [Header("Health Status")]
    public float currentHealth = 100;
    public float maxHealth = 100;

    [Header("Speed values")]
    public float walkingSpeed;
    public float runningSpeed;
    public float sneakMultiplier;
    public float jumpPower;

    public float GetCurHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetHealth(float currentHealth)
    {
        this.currentHealth = currentHealth;
    }

    public void SetMaxHealth(float maxHealth)
    {
        this.maxHealth = maxHealth;
    }
}
