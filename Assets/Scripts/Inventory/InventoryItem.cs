using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Use categories instead of useable etc. bools
public enum ItemCategory { Consumable, Useable, Equippable, Other }

public struct ContextAction
{
    public ItemCategory category;
    public string actionText;
}

public class InventoryItem : MonoBehaviour
{
    public float weigth;
    public Sprite icon;

    public virtual ItemCategory type { get; set; }

    [Header("Display properties")]
    public new string name;

    public string subname;

    [TextArea]
    public string description;

    //[Header("Context actions")]
    public virtual bool consumable { get; set; }

    public virtual bool useable { get; set; }
    public virtual bool equippable { get; set; }
    public virtual bool droppable { get; set; }

    public Sprite GetIcon()
    {
        return icon;
    }

    public string GetName()
    {
        return name;
    }

    public new string GetType()
    {
        return type.ToString();
    }

    public float GetWeight()
    {
        return weigth;
    }
}