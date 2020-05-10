using System.Collections.Generic;
using Stat;
using UnityEngine;
using Util;

namespace Character
{
    public abstract class CharacterProperties : AttributeHolder
    {
        [Header("Team ID")] public Float team;
        [Tooltip("Add IDs of all allied fractions.")]
        public List<int> allies;
        [Tooltip("Add IDs of all enemy fractions.")]
        public List<int> enemies;

        [Header("Health")] public Float health;
        public StatAttribute maxHealth;

        [Header("Armor")] public StatAttribute armor;

        [Header("Speed values")] public StatAttribute speed;
        public float sneakMultiplier = 0.7f;
        public float runMultiplier = 2f;

        public float jumpPower = 450f;

        [Header("Inventory")] [Tooltip("Current weight.")]
        public StatAttribute weight;

        [Tooltip("Maximum weight capacity of player in kg. Set to 0 for unlimited.")]
        public StatAttribute maxWeight;

        [Tooltip("Maximum slot capacity of player. Set to negative value for unlimited.")]
        public int slotCapacity = -1;

        /// <summary>
        /// This sums up the damage a character can potentially inflict. It is not the damage the character will receive.
        /// In addition if the character heals itself or others the potential healing amount should decrease the damage
        /// counter.
        /// </summary>
        [HideInInspector] public FloatVariable damageCounter;

        protected virtual void Start()
        {
            damageCounter = FloatVariable.Create(0, "DamageCounter");
            allies.Add((int) team.Value);
        }

        public void Heal(float value)
        {
            health.Value += value;
        }

        public void Damage(float value)
        {
            health.Value -= value;
        }

        public bool GetWeightCapacityEnabled()
        {
            return maxWeight.Value > 0;
        }

        public bool GetSlotCapacityEnabled()
        {
            return slotCapacity > 0;
        }

        public void DamageDealt(float damage)
        {
            damageCounter.Value += damage;
        }

        public void ResetDamageCounter()
        {
            damageCounter.Value = 0;
        }

        public float Relation(int otherTeamId)
        {
            if (allies.Contains(otherTeamId))
            {
                return 1f;
            }

            if (enemies.Contains(otherTeamId))
            {
                return -1f;
            }

            return 0;
        }
    }
}