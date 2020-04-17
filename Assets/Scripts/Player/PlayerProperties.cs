using Stat;
using UnityEngine;
using Util;

public class PlayerProperties : MonoBehaviour, IAttributeHolder
{
    [Header("Health")]
    public FloatVariable health;
    public StatAttribute maxHealth;
    
    [Header("Speed values")]
    public float walkingSpeed = 3f;

    public float runningSpeed = 6f;
    private float defaultWalkingSpeed = 3f;
    private float defaultRunningSpeed = 6f;

    public float sneakMultiplier = 0.7f;
    public float jumpPower = 450f;

    [Header("Inventory")]
    public float weight;

    [Tooltip("Maximum weight capacity of player in kg. Set to negative value for unlimited.")]
    public float weightCapacity = 50;

    [Range(0, 100)]
    [Tooltip("Weight Percentage of maximum capacity at which the player will receive movement penalties (Default 75%). Set to negative vlaue for none")]
    public float softCap = 75;

    [Tooltip("Maximum slot capacity of player. Set to negative value for unlimited.")]
    public int slotCapacity = -1;

    private void FixedUpdate()
    {
        health.Value = health.Value;
    }

    public float GetHealth()
    {
        return health.Value;
    }

    public void SetHealth(float value)
    {
        health.Value = value;
    }

    public void Heal(float value)
    {
        health.Value += value;
    }

    public void Damage(float value)
    {
        health.Value -= value;
    }

    public float GetWeightCapacity()
    {
        return weightCapacity;
    }

    public int GetSlotCapacity()
    {
        return slotCapacity;
    }

    public float GetWeight()
    {
        return weight;
    }

    public void SetWeight(float value)
    {
        weight = value;
    }

    public bool GetSlotCapacityEnabled()
    {
        return slotCapacity > 0;
    }

    public bool GetWeightCapacityEnabled()
    {
        return weightCapacity > 0;
    }

    public void CalculateSpeed()
    {
        float weightCapacityPercentage = weightCapacity / 100;
        float percentage = weight / weightCapacityPercentage;
        if (softCap > 0)
        {
            if (percentage < softCap)
            {
                runningSpeed = defaultRunningSpeed;
                walkingSpeed = defaultWalkingSpeed;
            }
            else
            {
                //runningSpeed = defaultRunningSpeed - (defaultRunningSpeed * ((percentage-75)/25));        //linear regression
                //walkingSpeed = defaultWalkingSpeed - (defaultWalkingSpeed * ((percentage - 75) / 25));
                runningSpeed = defaultRunningSpeed - (defaultRunningSpeed * Mathf.Pow((((percentage - softCap) / (100 - softCap))), 2f));   //quadratic regression
                walkingSpeed = defaultWalkingSpeed - (defaultWalkingSpeed * Mathf.Pow((((percentage - softCap) / (100 - softCap))), 2f));
            }
        }
    }

    public float GetSpeedPenaltyGradient()
    {
        /*float startPenaltyWeight;
        float endPenaltyWeight;*/
        float weightCapacityPercentage = weightCapacity / 100;
        float percentage = weight / weightCapacityPercentage;
        return ((percentage - softCap) / (100 - softCap)) * 100;
    }
    
    public StatAttribute GetAttribute(StatAttributeType attributeType)
    {
        return maxHealth.attributeType == attributeType ? maxHealth : null;
    }
}