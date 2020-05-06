using MenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : CloseableMenu
{
    public ControlsMenu controlsMenu;
    //The settings menu.
    public SettingsMenu settingsMenu;
    //The audio settings menu;
    public AudioSettingsMenu audioSettingsMenu;
    public string startMenu = "StartMenu";

    public void resumeButton()
    {
        Hide();
    }

    /// <summary>
    /// Opens the settings menu.
    /// </summary>
    public void SettingsButton()
    {
        settingsMenu.Show();
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