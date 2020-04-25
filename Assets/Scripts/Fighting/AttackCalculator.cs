using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCalculator : MonoBehaviour
{
    private GameObject _attachedGameobjekt;

    private void Start()
    {
        _attachedGameobjekt = transform.parent.gameObject;
    }
    public void CalculateDamage(float damage)
    {
        NPCProperties NPCProps = _attachedGameobjekt.GetComponent<NPCProperties>();
        NPCProps.health = Mathf.Clamp(NPCProps.health - damage, 0, NPCProps.maxHealth);
    }

    public void CalculateEffect()
    {

    }
}
