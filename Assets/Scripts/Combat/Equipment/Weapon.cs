using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 2)]
public class Weapon : ScriptableObject
{
    public float damage = 1f;
}
