using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform origin;
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
            hit.collider.GetComponent<Hitbox>().DoHitEffects(gameObject);
        }

    }

    private void PlayAttackAnimation()
    {
        // empty call, to be filled
    }
}
