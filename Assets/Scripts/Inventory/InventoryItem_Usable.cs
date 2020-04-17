using UnityEngine;

[AddComponentMenu("Inventory/Item/Usable")]
public class InventoryItem_Usable : InventoryItem
{
    /*[Header("Restore Health")]
    public bool effect_restoreHealth;
    
    public float healthAmount;*/

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
        /*if (effect_restoreHealth)
        {
            PlayerProperties.instance.Heal(healthAmount);
        }*/
    }
}