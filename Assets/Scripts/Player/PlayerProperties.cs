using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    [Header("Health Status")]
    public float currentHealth = 100f;
    public float maxHealth = 100f;

    [Header("Speed values")]
    public float walkingSpeed = 3f;
    public float runningSpeed = 6f;
    public float sneakMultiplier = 0.7f;
    public float jumpPower = 450f;

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
