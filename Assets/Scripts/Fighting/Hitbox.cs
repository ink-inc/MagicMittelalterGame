using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class Hitbox : MonoBehaviour
    {
        public float damageMultiplier = 1f;
        public string hitboxType = "default";

        public AttackCalculator attackCalculator { get; set; }

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
            attackCalculator.CalculateDamage(5 * damageMultiplier); // TODO: Use actual weapon damage instead of hardcoded placeholder
            attackCalculator.CalculateEffect();
        }
    }
}
