using UnityEngine;

[AddComponentMenu("Inventory/Item/Consumable")]
public class InventoryItem_Consumable : InventoryItem
{
    //Possible refactor: Effect-upper class -> Can be attached to anything that uses an effect, potions etc.

    private void Reset()
    {
        consumable = true;
        useable = false;
        equippable = false;
        droppable = true;
        type = ItemCategory.Consumable;
    }

    public override void ContextAction()
    {
        Logger.log("Consume " + name);
        inventory.Remove(this, true);
    }
}