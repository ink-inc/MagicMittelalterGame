using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public PlayerProperties playerProperties;

    //Put into PlayerProperties
    private float weight;

    private int slotsFilled;
    private List<InventoryItem> inventory;

    private void Start()
    {
        inventory = new List<InventoryItem>();
    }

    public bool Pickup(InventoryItem item)
    {
        if (CanPickup(item.weigth))
        {
            inventory.Add(item);
            slotsFilled++;
            weight += item.weigth;
            return true;
        }
        return false;
    }

    public bool CanPickup(float itemWeight)
    {
        //TODO: This is ugly... but it should work
        return (playerProperties.GetWeightCapacity() < 0 || weight + itemWeight <= playerProperties.GetWeightCapacity()) && (playerProperties.GetSlotCapacity() < 0 || slotsFilled <= playerProperties.GetSlotCapacity());
    }
}