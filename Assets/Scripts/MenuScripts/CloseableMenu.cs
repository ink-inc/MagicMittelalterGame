using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseableMenu : MonoBehaviour
{
    [Header("Closeable Menu Values")]
    public static Stack<CloseableMenu> openMenues = new Stack<CloseableMenu>();

    public GameObject menuObject;
    public bool active = false;
    public bool hideIfNotOnTop = false;

    private void Start()
    {
        active = menuObject.activeSelf;
    }

    public virtual void Toggle()
    {
        if (active)
            Hide();
        else
            Show();
    }

    public virtual void Show()
    {
        Logger.log("Showing: " + gameObject.name);
        active = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        if (openMenues.Count > 0)
        {
            if (openMenues.Peek().hideIfNotOnTop) //Hide Menu below, if wanted
            {
                Logger.log(openMenues.Peek().menuObject.name + " wants to be closed, as it is below: ");
                openMenues.Peek().menuObject.SetActive(false);
            }
        }
        openMenues.Push(this);
        menuObject.SetActive(active);
        Logger.log("Menu active.");
        PrintMenuStack();
    }

    public virtual void Hide()
    {
        CloseableMenu topMenu = openMenues.Pop();
        topMenu.active = false;
        topMenu.menuObject.SetActive(false);
        if (openMenues.Count == 0)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1f;
        }
        else
        {
            CloseableMenu newTop = openMenues.Peek();
            if (newTop.hideIfNotOnTop)
                newTop.menuObject.SetActive(true);
        }
        PrintMenuStack();
    }

    private void PrintMenuStack()
    {
        Stack<CloseableMenu> temp = new Stack<CloseableMenu>();
        int i = 0;
        while (openMenues.Count > 0)
        {
            CloseableMenu top = openMenues.Pop();
            Logger.log("[" + i + "] :" + top.menuObject.name);
            temp.Push(top);
            i--;
        }
        while (temp.Count > 0)
        {
            openMenues.Push(temp.Pop());
        }
    }

    public void Clean()
    {
        openMenues.Clear();
    }
}