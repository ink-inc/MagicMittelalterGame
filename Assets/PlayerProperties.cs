using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProperties : MonoBehaviour
{

    [Header("Health Status")]
    public float currentHealth = 100;
    public float maxHealth = 100;

    public float GetCurHealth()
    {
        return currentHealth;
    }

    public float GetMaxHealth()
    {
        return maxHealth;
    }
}
