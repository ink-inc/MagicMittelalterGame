using MenuScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : CloseableMenu
{
    public ControlsMenu controlsMenu;
    //The settings menu.
    public SettingsMenu settingsMenu;
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
        Application.Quit();
    }

    public void menuButton()
    {
        SceneManager.LoadScene(startMenu);
    }
}