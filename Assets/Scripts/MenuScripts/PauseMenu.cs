using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject menu;
    public string startMenu = "StartMenu";

    public void resumeButton ()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        menu.SetActive(false);
    }

    public void controlsButton ()
    {
        Debug.Log("Gello");
        controlsMenu.SetActive(true);
        this.gameObject.SetActive(false);
    }

    public void exitButton ()
    {
        Application.Quit();
    }

    public void menuButton() 
    {
        SceneManager.LoadScene(startMenu);
    }
}


    