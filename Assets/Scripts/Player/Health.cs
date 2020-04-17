using Stat;
using UnityEngine;
using Util;

namespace Player
{
    [AddComponentMenu("Health")]
    public class Health : MonoBehaviour, IAttributeHolder
    {
        public FloatVariable health;
        public StatAttribute maxHealth;

        private void FixedUpdate()
        {
            health.Value = health.Value;
        }

        public float GetHealth()
        {
            return health.Value;
        }

        public void SetHealth(float value)
        {
            health.Value = value;
        }

        public void Heal(float value)
        {
            health.Value += value;
        }

        public void Damage(float value)
        {
            health.Value -= value;
        }

        public StatAttribute GetAttribute(StatAttributeType attributeType)
        {
            return maxHealth.attributeType == attributeType ? maxHealth : null;
        }
    }
}