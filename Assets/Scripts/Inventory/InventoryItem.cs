using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Use categories instead of useable etc. bools
public enum ItemCategory { Consumable, Useable, Equippable, Other }

public class InventoryItem : MonoBehaviour
{
    public float weigth;

    [Header("Display properties")]
    public new string name;

    public string subname;
    public string description;

    [Header("Context actions")]
    public bool consumable;

    public bool useable;
    public bool equippable;
    public bool droppable = true;
}