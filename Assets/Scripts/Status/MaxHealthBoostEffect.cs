using System;
using JetBrains.Annotations;
using Stat;
using UnityEngine;

namespace Status
{
    public class MaxHealthBoostEffect : StatusEffect
    {
        public override string Id => "max_health_boost";

        public float MaxHealthBoost
        {
            get => _maxHealthBoost;
            set
            {
                _maxHealthBoost = value;
                if (_maxHealthBoostModifier != null)
                {
                    _maxHealthBoostModifier.Value = MaxHealthBoost;
                }
            }
        }

        private float _maxHealthBoost;
        [CanBeNull] private StatModifier _maxHealthBoostModifier;

        public MaxHealthBoostEffect(float maxHealthBoost, int duration = 0) : base(duration)
        {
            MaxHealthBoost = maxHealthBoost;
        }

        public override void OnEnable()
        {
            base.OnEnable();

            if (Holder.TryGetComponent<PlayerProperties>(out var playerProperties))
            {
                _maxHealthBoostModifier = new StatModifier(
                    MaxHealthBoost,
                    StatModifierType.Additive,
                    this
                );
                playerProperties.maxHealth.AddModifier(_maxHealthBoostModifier);
            }
        }

        public override void OnDisable()
        {
            base.OnDisable();
            _maxHealthBoostModifier = null;
        }

        public override void Merge(StatusEffect newEffect)
        {
            if (newEffect is MaxHealthBoostEffect boost)
            {
                base.Merge(newEffect);

                MaxHealthBoost += boost.MaxHealthBoost;
                if (Mathf.Abs(MaxHealthBoost) < 1e-4)
                {
                    MarkForRemoval();
                }
            }
            else
            {
                throw new ArgumentException("type mismatch");
            }
        }
    }
}