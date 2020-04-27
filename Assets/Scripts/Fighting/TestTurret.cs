using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTurret : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TurretFire());
    }

    private IEnumerator TurretFire()
    {
        while (true) {
            Debug.DrawRay(transform.position, transform.forward, Color.red);
            if (Physics.Raycast(transform.position, transform.forward, out var hit, 5f) /* && hit.collider.GetComponent<Hitbox>() != null*/)
            {
                Debug.Log("Hit");
                hit.collider.GetComponent<Hitbox>().DoHitEffects(gameObject);
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
