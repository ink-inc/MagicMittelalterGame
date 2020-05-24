using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image iconSmoll;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI typeText;
    public TextMeshProUGUI weightText;
    public Image equippedOverlay;

    public void Display(InventoryItem item)
    {
        iconSmoll.sprite = item.GetIcon();
        titleText.text = item.GetName();
        Logger.log("Displaying " + item.name + " -> " + item.GetType());
        typeText.text = item.GetType();
        weightText.text = item.GetWeight().ToString();
        if (item is InventoryItem_Equippable)
        {
            InventoryItem_Equippable itemE = (InventoryItem_Equippable)item;
            SetEquippedOverlay(itemE.IsEquipped());
        }
    }

    public void SetEquippedOverlay(bool visible = true)
    {
        equippedOverlay.gameObject.SetActive(visible);
    }
}