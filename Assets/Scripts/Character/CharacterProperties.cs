using Stat;
using UnityEngine;
using Util;

namespace Character
{
    public abstract class CharacterProperties : AttributeHolder
    {
        [Header("Team ID")] public Float team;

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
        /// This sums up the damage a character can potentially inflect. It is not the damage the character will receive.
        /// </summary>
        [HideInInspector] public FloatVariable damageCounter;

        protected virtual void Start()
        {
            damageCounter = FloatVariable.Create(0, "DamageCounter");
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
    }
}