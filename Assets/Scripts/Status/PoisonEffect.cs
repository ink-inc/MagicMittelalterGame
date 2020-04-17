using Player;
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
            if (instance.Holder.TryGetComponent<Health>(out var health))
            {
                health.Damage(damage);
            }

            base.Tick(instance);
        }
    }
}