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
        public void CalculateDamage(PlayerProperties attackerProperties, float hitboxDamageMultiplier)
        {
            float resultDamage = (attackerProperties.weapon.damage * hitboxDamageMultiplier);
            attachedProperties.Damage(resultDamage);
        }

        public void CalculateEffect()
        {
            // TODO: Empty call, add Miles' status Effects
        }
    }
}
