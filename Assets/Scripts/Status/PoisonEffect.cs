using System;
using UnityEngine;

namespace Status
{
    public class PoisonEffect : TimedEffect
    {
        public override string Id => "poison";

        public float Damage
        {
            get => _damage;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("damage must be positive");
                }

                _damage = value;
            }
        }

        private float _damage;

        public PoisonEffect(float damage, int duration) : base(duration)
        {
            Damage = damage;
        }

        public override void Tick()
        {
            if (Holder.TryGetComponent<PlayerProperties>(out var playerProperties))
            {
                playerProperties.Damage(Damage);
            }

            base.Tick();
        }

        public override void Merge(StatusEffect newEffect)
        {
            if (newEffect is PoisonEffect poison)
            {
                base.Merge(poison);

                Damage = Mathf.Max(Damage, poison.Damage);
            }
            else
            {
                throw new ArgumentException("type mismatch");
            }
        }
    }
}