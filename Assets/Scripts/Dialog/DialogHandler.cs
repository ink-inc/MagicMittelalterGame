using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{
    public GameObject dialogInterface;

    public void StartDialog(int id)
    {
        dialogInterface.SetActive(true);
        Debug.Log("2");
    }

    private void DialogLoop()
    {

    }

    private void PresentText()
    {

    }

    private void SayLine()
    {

    }

    private void GetDecision()
    {

    }
}
