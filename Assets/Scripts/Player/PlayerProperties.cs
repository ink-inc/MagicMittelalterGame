using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{
    [Header("Health Status")]
    public float health = 100f;

    public float maxHealth = 100f;

    [Header("Speed values")]
    public float walkingSpeed = 3f;

    public float runningSpeed = 6f;
    public float sneakMultiplier = 0.7f;
    public float jumpPower = 450f;

    [Header("Inventory")]
    [Tooltip("Maximum weight capacity of player in kg. Set to negative value for unlimited.")]
    public float weightCapacity = 50;

    [Tooltip("Maximum slot capacity of player. Set to negative value for unlimited.")]
    public int slotCapacity = -1;

    public float GetHealth()
    {
        return health;
    }

    public void SetHealth(float value)
    {
        this.health = value;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }

    public void SetMaxHealth(float value)
    {
        this.maxHealth = value;
    }

    public float GetWeightCapacity()
    {
        return weightCapacity;
    }

    public int GetSlotCapacity()
    {
        return slotCapacity;
    }
}