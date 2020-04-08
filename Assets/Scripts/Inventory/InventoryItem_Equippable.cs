using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item/Equippable")]
public class InventoryItem_Equippable : InventoryItem
{
    public new bool consumable = false;
    public new bool useable = false;
    public new bool equippable = true;
    public new bool droppable = true;
    public new ItemCategory type = ItemCategory.Equippable;

    public override void ContextAction()
    {
        Logger.log("Equip " + name);
    }

    public override string GetType()
    {
        return type.ToString();
    }
}