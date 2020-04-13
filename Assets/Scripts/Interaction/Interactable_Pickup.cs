using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Interaction/Interactable/Pickup")]
public class Interactable_Pickup : Interactable
{
    public InventoryItem itemToPickup;
    public Inventory inventory;

    private void Awake()
    {
        displayText = itemToPickup.name;
        displaySubtext = "[E] to pick up"; //Override subtext for all pickupables
    }

    public override void interact()
    {
        itemToPickup.gameObject.SetActive(!inventory.Pickup(itemToPickup));
    }
}