using Stat;
using UnityEngine;
using Util;

public class PlayerProperties : MonoBehaviour, IAttributeHolder
{
    [Header("Health")]
    public Float health;
    public StatAttribute maxHealth;

    [Header("Speed values")]
    public StatAttribute speed;
    public float sneakMultiplier = 0.7f;
    public float runMultiplier = 2f;

    public float jumpPower = 450f;

    [Header("Inventory")]
    [Tooltip("Current weight.")]
    public StatAttribute weight;

    [Tooltip("Maximum weight capacity of player in kg. Set to 0 for unlimited.")]
    public StatAttribute maxWeight;

    [Tooltip("Maximum slot capacity of player. Set to negative value for unlimited.")]
    public int slotCapacity = -1;

    public void Heal(float value)
    {
        health.Value += value;
    }

    public void Damage(float value)
    {
        health.Value -= value;
    }

    public bool GetWeightCapacityEnabled()
    {
        return maxWeight.Value > 0;
    }
    
    public bool GetSlotCapacityEnabled()
    {
        return slotCapacity > 0;
    }

    public StatAttribute GetAttribute(StatAttributeType attributeType)
    {
        if (maxHealth.attributeType.Type == attributeType.Type)
        {
            return maxHealth;
        }

        if (speed.attributeType.Type == attributeType.Type)
        {
            return speed;
        }

        if (weight.attributeType.Type == attributeType.Type)
        {
            return weight;
        }

        if (maxWeight.attributeType.Type == attributeType.Type)
        {
            return maxWeight;
        }

        return null;
    }
}