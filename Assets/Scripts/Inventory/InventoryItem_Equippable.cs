using UnityEngine;

namespace Inventory
{
    [AddComponentMenu("Inventory/Item/Equippable")]
    public class InventoryItem_Equippable : InventoryItem
    {
        private void Reset()
        {
            consumable = false;
            useable = false;
            equippable = true;
            droppable = true;
            type = ItemCategory.Equippable;
        }

        public override void ContextAction()
        {
            Logger.log("Equip " + name);
        }
    }
}