using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Inventory
{

    [AddComponentMenu("Inventory/Inventory")]
    public class Inventory : MonoBehaviour
    {
        public PlayerProperties playerProperties;
        public InventoryDisplay inventoryDisplay;
        public Transform itemDropLocation;

        private int slotsFilled;
        private List<InventoryItem> inventory;

        private void Start()
        {
            inventory = new List<InventoryItem>();
        }

        public InventoryItem[] GetItems()
        {
            return inventory.ToArray();
        }

        public int GetSlotsUsed()
        {
            return inventory.Count;
        }

        public Transform GetItemDropLocation()
        {
            return itemDropLocation;
        }

        public bool Pickup(InventoryItem item)
        {
            if (CanPickup(item.weigth))
            {
                inventory.Add(item);
                item.inventory = this;
                playerProperties.SetWeight(playerProperties.GetWeight() + item.weigth);
                RefreshInventory();
                return true;
            }

            return false;
        }

        public void Remove(InventoryItem item, bool destroy = false)
        {
            inventory.Remove(item);
            playerProperties.SetWeight(playerProperties.GetWeight() - item.weigth);
            RefreshInventory();
            if (destroy)
            {
                Destroy(item.gameObject);
            }
        }

        private void RefreshInventory()
        {
            slotsFilled = inventory.Count;
            playerProperties.CalculateSpeed();
            inventoryDisplay.CloseContextMenu();
            if (inventoryDisplay.active)
            {
                inventoryDisplay.Hide();
                inventoryDisplay.Show();
            }
        }

        public bool CanPickup(float itemWeight)
        {
            //TODO: This is ugly... but it should work
            float weight = playerProperties.GetWeight();
            return (playerProperties.GetWeightCapacity() < 0 ||
                    weight + itemWeight <= playerProperties.GetWeightCapacity()) &&
                   (playerProperties.GetSlotCapacity() < 0 || slotsFilled <= playerProperties.GetSlotCapacity());
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                inventoryDisplay.Toggle();
            }
        }
    }
}