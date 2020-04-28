using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Fighting
{
    public class Attacker : MonoBehaviour
    {
        public Transform origin;
        public List<AttackCombo> attackCombos = new List<AttackCombo>();

        private List<string> _attacksMade = new List<string>();
        private GameObject _lastHitCharacter;
        

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                LaunchAttack();
            }
        }

        private void LaunchAttack()
        {
            PlayAttackAnimation();
            if (Physics.Raycast(origin.position, origin.forward, out var hit, 5f) && hit.collider.GetComponent<Hitbox>() != null)
            {
                Hitbox hitbox = hit.collider.GetComponent<Hitbox>();
                hitbox.DoHitEffects(gameObject);

                if (_lastHitCharacter != hitbox.attackCalculator.attachedGameobjekt) _attacksMade.Clear();

                _attacksMade.Insert(0, hitbox.hitboxType);
                _lastHitCharacter = hitbox.attackCalculator.attachedGameobjekt;

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
            hitbox.attackCalculator.CalculateDamage(5f * combo.damageMultiplier); // TODO: Use weapon damage instead of hardcoded placeholder
        }

        private void PlayAttackAnimation()
        {
            // TODO: empty call, to be filled
        }
    }
}
