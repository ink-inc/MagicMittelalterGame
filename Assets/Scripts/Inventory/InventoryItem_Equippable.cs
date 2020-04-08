using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem_Equippable : InventoryItem
{
    public new bool consumable = false;
    public new bool useable = false;
    public new bool equippable = true;
    public new bool droppable = true;
    public new ItemCategory type = ItemCategory.Equippable;
}