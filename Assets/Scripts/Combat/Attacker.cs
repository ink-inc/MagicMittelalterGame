using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Fighting
{
    public class Attacker : MonoBehaviour
    {
        public Transform origin;
        public List<AttackCombo> attackCombos = new List<AttackCombo>();

        public PlayerProperties attackerProperties;

        private List<string> _attacksMade = new List<string>();
        private GameObject _lastHitCharacter;

        private long _lastAttacktime;

        private void Start()
        {
            attackerProperties = gameObject.GetComponent<PlayerProperties>();
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                LaunchAttack();
            }
            CheckIfAttacksMadeShouldBeReset();
        }

        private void CheckIfAttacksMadeShouldBeReset()
        {
            if (_attacksMade.Count == 0) return;

            if (DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() - _lastAttacktime > 2000) // To get a reset after a different timespan, change the amount of Milliseconds
            {
                _attacksMade.Clear();
            }
        }

        private void LaunchAttack()
        {
            PlayAttackAnimation();
            if (Physics.Raycast(origin.position, origin.forward, out var hit, 5f) && hit.collider.GetComponent<Hitbox>() != null)
            {
                Hitbox hitbox = hit.collider.GetComponent<Hitbox>();
                hitbox.DoHitEffects(attackerProperties);

                if (_lastHitCharacter != hitbox.attackCalculator.gameObject) _attacksMade.Clear();

                _attacksMade.Insert(0, hitbox.hitboxType);
                _lastHitCharacter = hitbox.attackCalculator.gameObject;
                _lastAttacktime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

                AttackCombo combo = CheckForCombo();
                if (combo != null)
                {
                    DoComboEffects(hitbox, combo);
                }
            }

        }

        private AttackCombo CheckForCombo()
        {
            if (attackCombos.Count == 0)
            {
                return null;
            }
            for (int i = 1; i <= _attacksMade.Count; i++)
            {
                List<string> subAttacksMade = _attacksMade.GetRange(0, i);
                subAttacksMade.Reverse();
                for (int j = 0; j < attackCombos.Count; j++)
                {
                    if (Utility.EqualSequence(attackCombos[j].attacksNeeded, subAttacksMade))
                    {
                        _attacksMade.Clear();
                        return attackCombos[j];
                    }
                }
            }
            return null;
        }

        private void DoComboEffects(Hitbox hitbox, AttackCombo combo)
        {
            hitbox.attackCalculator.CalculateDamage(attackerProperties, combo.damageMultiplier); // TODO: Use weapon damage instead of hardcoded placeholder
        }

        private void PlayAttackAnimation()
        {
            // TODO: empty call, to be filled
        }
    }
}
