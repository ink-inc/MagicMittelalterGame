using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class AttackCalculator : MonoBehaviour
    {
        public PlayerProperties attachedProperties { get; set; }

        private void Start()
        {
            attachedProperties = transform.parent.gameObject.GetComponent<PlayerProperties>();
        }
        public void CalculateDamage(PlayerProperties attackerProperties, Hitbox hitbox)
        {
            float weaponDamage = 1f;
            float armorProtection = 0f;

            // check if the Attacker carries a weapon
            if (attackerProperties.weapon != null)
            {
                weaponDamage = attackerProperties.weapon.damage;
            }

            // get the correct piece of armor
            if ()
            {

            }

            float resultDamage = (weaponDamage * hitbox.damageMultiplier);
            attachedProperties.Damage(resultDamage);
        }

        public void CalculateEffect()
        {
            // TODO: Empty call, add Miles' status Effects
        }
    }
}
