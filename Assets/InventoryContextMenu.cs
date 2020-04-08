using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryContextMenu : CloseableMenu
{
    public Transform contextMenuParent;
    public GameObject contextMenuButtonPrefab;
    public InventoryItem item;

    public override void Show()
    {
        base.Show();
        GameObject contextButtoninstance = Instantiate(contextMenuButtonPrefab, contextMenuParent);
        contextButtoninstance.GetComponent<Button>().onClick.AddListener(() => item.ContextAction());
        contextButtoninstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = item.contextActionName;

        Logger.log("Darf man das Item droppen? " + item.droppable);
        //if (item.droppable)
        //{
        GameObject dropButtonInstance = Instantiate(contextMenuButtonPrefab, contextMenuParent);
        dropButtonInstance.GetComponent<Button>().onClick.AddListener(() => item.Drop());
        dropButtonInstance.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Fallen lassen";
        //}
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