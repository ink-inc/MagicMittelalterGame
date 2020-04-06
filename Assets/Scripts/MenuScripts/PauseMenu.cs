using UnityEngine;
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
        Application.Quit();
    }

    public void menuButton()
    {
        SceneManager.LoadScene(startMenu);
    }
}