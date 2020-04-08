using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_Pickup : Interactable
{
    public InventoryItem itemToPickup;
    public Inventory inventory;

    private void Awake()
    {
        displaySubtext = "[E] to pick up"; //Override subtext for all pickupables
    }

    public override void interact()
    {
        itemToPickup.gameObject.SetActive(!inventory.Pickup(itemToPickup));
    }
}