using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo
{
    public List<string> attacksNeeded { get; set; } = new List<string>();
    public float damageMultiplier = 4f;

    public AttackCombo()
    {
        attacksNeeded.Add("Head");
        attacksNeeded.Add("Head");
        attacksNeeded.Add("Head");
    }
}
