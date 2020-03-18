using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject controlsMenu;
    public GameObject menu;

    public void resumeButton ()
    {
        Cursor.lockState = CursorLockMode.Locked;
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
}
