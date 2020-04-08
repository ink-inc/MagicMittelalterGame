using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem_Consumable : InventoryItem
{
    public new bool consumable = true;
    public new bool useable = false;
    public new bool equippable = false;
    public new bool droppable = true;
    public new ItemCategory type = ItemCategory.Consumable;
}