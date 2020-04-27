using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCombo
{
    public List<string> attacksNeeded { get; set; } = new List<string>();

    public AttackCombo()
    {
        attacksNeeded.Add("head");
        attacksNeeded.Add("head");
        attacksNeeded.Add("head");
    }
}
