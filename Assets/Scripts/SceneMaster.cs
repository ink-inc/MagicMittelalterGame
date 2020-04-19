using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMaster : MonoBehaviour
{
    public PauseMenu pauseMenu;

    private void OnApplicationFocus(bool focus)
    {
        Debug.Log(focus);
        if (focus == false)
        {
            pauseMenu.Show();
        }
    }
}
