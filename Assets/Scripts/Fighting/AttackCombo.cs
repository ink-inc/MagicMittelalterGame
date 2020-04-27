using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo
{
    public List<string> attacksNeeded { get; set; } = new List<string>();
    public float damageMultiplier { get; set; }

    public AttackCombo()
    {
        damageMultiplier = 4f;
        attacksNeeded.Add("Head");
        attacksNeeded.Add("Head");
        attacksNeeded.Add("Head");
    }

    public AttackCombo (List<string> strikes, float damage)
    {
        this.attacksNeeded = strikes;
        this.damageMultiplier = damage;
    }
}
