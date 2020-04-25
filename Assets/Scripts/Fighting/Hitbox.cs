using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public float damageMultiplier;
    public void DoHitEffects(GameObject Attacker)
    {
        transform.parent.gameObject.GetComponent<AttackCalculator>().CalculateDamage(5 * damageMultiplier);
        transform.parent.gameObject.GetComponent<AttackCalculator>().CalculateEffect();
    }
}
