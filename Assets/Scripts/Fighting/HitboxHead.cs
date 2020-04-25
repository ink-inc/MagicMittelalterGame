using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxHead : Hitbox
{
    public override void DoHitEffects(GameObject Attacker)
    {
        transform.parent.gameObject.GetComponent<AttackCalculator>().CalculateDamage(5f);
    }
}
