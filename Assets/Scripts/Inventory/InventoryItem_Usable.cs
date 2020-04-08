using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item/Usable")]
public class InventoryItem_Usable : InventoryItem
{
    public new bool consumable = false;
    public new bool useable = true;
    public new bool equippable = false;
    public new bool droppable = true;
    public new ItemCategory type = ItemCategory.Useable;
}