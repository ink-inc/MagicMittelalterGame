using UnityEngine;

namespace Interaction
{
    [AddComponentMenu("Interaction/Interactable/ItemPickup")]
    public class InteractableItemPickup : Interactable
    {
        public InventoryItem pickupItem;

        private void Start()
        {
            if (pickupItem == null)
            {
                pickupItem = GetComponent<InventoryItem>();
            }
            
            displayText = pickupItem.name;
            displaySubtext = "[E] to pick up"; //Override subtext for all pickupables
        }

        public override void Interact(Interactor interactor)
        {
            var inventory = interactor.GetComponent<Inventory>();
            pickupItem.gameObject.SetActive(!inventory.Pickup(pickupItem));
        }
    }
}