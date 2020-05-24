using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fighting
{
    public class TestTurret : MonoBehaviour
    {
        private PlayerProperties playerProperties;
        void Start()
        {
            Weapon weapon = new Weapon();
            weapon.damage = 5;
            playerProperties.weapon = weapon;
            StartCoroutine(TurretFire());
        }

        private IEnumerator TurretFire()
        {
            while (true)
            {
                Debug.DrawRay(transform.position, transform.forward, Color.red);
                if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f) && hit.collider.TryGetComponent<Hitbox>(out Hitbox hitbox))
                {
                    hitbox.DoHitEffects(new PlayerProperties());
                }
                yield return new WaitForSeconds(1f);
            }
        }
    }
}
