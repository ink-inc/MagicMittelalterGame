﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : CloseableMenu
{
    public ControlsMenu controlsMenu;
    public string startMenu = "StartMenu";

    public void resumeButton()
    {
        Hide();
    }

    public void controlsButton()
    {
        controlsMenu.Show();
    }

    public void exitButton()
    {
        openMenues.Clear();
        Application.Quit();
    }

    public void menuButton()
    {
        openMenues.Clear();
        SceneManager.LoadScene(startMenu);
    }
}