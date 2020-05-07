using UnityEngine;

[AddComponentMenu("Inventory/Item/Usable")]
public class InventoryItem_Usable : InventoryItem
{
    private void Reset()
    {
        consumable = false;
        useable = true;
        equippable = false;
        droppable = true;
        type = ItemCategory.Useable;
    }

    public override void ContextAction()
    {
        Logger.log("Use " + name);
    }
}