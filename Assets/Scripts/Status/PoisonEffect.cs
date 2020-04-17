using UnityEngine;

namespace Status
{
    [CreateAssetMenu(menuName = "StatusEffect/Poison")]
    public class PoisonEffect : TimedEffect
    {
        /// <summary>
        /// Damage per tick.
        /// </summary>
        public float damage;

        public override void Tick(StatusEffectInstance instance)
        {
            if (instance.Holder.TryGetComponent<PlayerProperties>(out var playerProperties))
            {
                playerProperties.Damage(damage);
            }

            base.Tick(instance);
        }
    }
}