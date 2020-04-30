using UnityEngine;
using UnityEngine.UI;

namespace Inventory {
    public class InventorySlot : MonoBehaviour
    {
        public Image iconSmoll;
        public TextMeshProUGUI titleText;
        public TextMeshProUGUI typeText;
        public TextMeshProUGUI weightText;

        public void Display(InventoryItem item)
        {
            iconSmoll.sprite = item.GetIcon();
            titleText.text = item.GetName();
            Logger.log("Displaying " + item.name + " -> " + item.GetType());
            typeText.text = item.GetType();
            weightText.text = item.GetWeight().ToString();
        }
    }
}