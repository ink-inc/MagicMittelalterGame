using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damageMultiplier = 1f;

    private AttackCalculator attackCalculator;

    public void Start()
    {
        Transform attackParent = transform;
        bool doLoop = true;
        while (doLoop)
        {
            attackParent = attackParent.parent;
            if (attackParent.GetComponent<AttackCalculator>() != null)
            {
                doLoop = false;
            }
        }
        attackCalculator = attackParent.GetComponent<AttackCalculator>();
    }
    public void DoHitEffects(GameObject Attacker)
    {
        attackCalculator.CalculateDamage(5 * damageMultiplier);
        attackCalculator.CalculateEffect();
    }
}
