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

            // get the protection value of the correct armor piece
            foreach(Armor piece in attachedProperties.armorPieces)
            {
                if (piece.armorType.Equals(hitbox.hitboxType)) armorProtection = piece.protection;
            }

            // the actual damage calculation
            float resultDamage = Mathf.Round((weaponDamage * hitbox.damageMultiplier) / (armorProtection + 1 /* through 0 would be a problem*/));
            attachedProperties.Damage(resultDamage);
        }

        public void CalculateComboDamage(PlayerProperties attackerProperties, float damageMultiplier)
        {
            float weaponDamage = 1f;
            float armorProtection = 0f;

            // check if the Attacker carries a weapon
            if (attackerProperties.weapon != null)
            {
                weaponDamage = attackerProperties.weapon.damage;
            }

            // add the protection value of every armor piece together and divide them by the amount of armor pieces possible
            foreach (Armor piece in attachedProperties.armorPieces)
            {
                armorProtection += piece.protection;
            }
            armorProtection /= attachedProperties.allowedArmorPieces.Count;

            float resultDamage = Mathf.Round((weaponDamage * damageMultiplier) / (armorProtection + 1 /* through 0 would be a problem*/));
            attachedProperties.Damage(resultDamage);
        }

        public void CalculateEffect()
        {
            // TODO: Empty call, add Miles' status Effects
        }
    }
}
