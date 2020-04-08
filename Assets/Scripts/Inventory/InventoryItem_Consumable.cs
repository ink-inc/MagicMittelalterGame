using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Inventory/Item/Consumable")]
public class InventoryItem_Consumable : InventoryItem
{
    public new bool consumable = true;
    public new bool useable = false;
    public new bool equippable = false;
    public new bool droppable = true;
    public new ItemCategory type = ItemCategory.Consumable;

    public override void ContextAction()
    {
        Logger.log("Consume " + name);
    }

    public override string GetType()
    {
        return type.ToString();
    }
}