using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryContextMenu : CloseableMenu
{
    public Transform contextMenuParent;
    public GameObject contextMenuButtonPrefab;
    private InventoryItem item;

    public void feed(InventoryItem item)
    {
        this.item = item;
    }

    public override void Show()
    {
        base.Show();
        Logger.log("Showing context menu for " + item.name);
        GameObject contextButtoninstance = Instantiate(contextMenuButtonPrefab, contextMenuParent);
        contextButtoninstance.GetComponent<Button>().onClick.AddListener(() => item.ContextAction());
        contextButtoninstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.contextActionName;

        if (item.droppable)
        {
            GameObject dropButtonInstance = Instantiate(contextMenuButtonPrefab, contextMenuParent);
            dropButtonInstance.GetComponent<Button>().onClick.AddListener(() => item.Drop());
            dropButtonInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fallen lassen";
        }
        Vector2 menuPos = Input.mousePosition;
        menuPos.x += 150;
        menuPos.y -= 60;
        transform.position = menuPos;
    }

    public override void Hide()
    {
        for (int i = 0; i < contextMenuParent.childCount; i++)
        {
            Destroy(contextMenuParent.GetChild(i).gameObject);
        }
        base.Hide();
    }
}