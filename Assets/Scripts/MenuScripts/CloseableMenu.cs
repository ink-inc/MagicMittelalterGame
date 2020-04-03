using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseableMenu : MonoBehaviour
{
    [Header("Closeable Menu Values")]
    public static Stack<CloseableMenu> openMenues = new Stack<CloseableMenu>();

    public GameObject menuObject;
    public bool active = false;

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
        active = true;
        openMenues.Push(this);
        menuObject.SetActive(active);
    }

    public virtual void Hide()
    {
        CloseableMenu topMenu = openMenues.Pop();
        topMenu.active = false;
        topMenu.menuObject.SetActive(false);
    }
}