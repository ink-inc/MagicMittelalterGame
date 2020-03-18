using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }
    public void backButton()
    {
        this.gameObject.SetActive(false);
        pauseMenu.SetActive(true);
    }
}
