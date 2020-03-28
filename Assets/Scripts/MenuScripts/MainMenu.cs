using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string mainScene = "Main";
    public void StartGameButton()
    {
        SceneManager.LoadScene(mainScene);
        Time.timeScale = 1;
    }

    public void ExitGameButton()
    {
        Application.Quit();
    }
}
