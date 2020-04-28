using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    [CreateAssetMenu(fileName = "Combo", menuName = "ScriptableObjects/AttackCombo", order = 1)]
    public class AttackCombo : ScriptableObject
    {
        [Tooltip("The List of Attack needed: Head, Torso, Arm, Leg are available right now.")]
        public List<string> attacksNeeded;
        [Tooltip("The number the weapon damage will be multiplied with.")]
        public float damageMultiplier;
        [Tooltip("Placeholder for the effects that will be applied by the combo.")]
        public List<string> effect;

        public AttackCombo()
        {
            damageMultiplier = 4f;
            attacksNeeded.Add("Head");
            attacksNeeded.Add("Head");
            attacksNeeded.Add("Head");
        }

        public AttackCombo(List<string> strikes, float damage)
        {
            this.attacksNeeded = strikes;
            this.damageMultiplier = damage;
        }
    }
}
