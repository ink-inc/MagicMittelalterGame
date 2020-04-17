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
                Logger.logWarning("Interactable pickupItem is missing and has been automatically assigned. Please assign it manually.");
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