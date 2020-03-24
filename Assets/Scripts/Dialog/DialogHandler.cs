using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogHandler : MonoBehaviour
{
    public GameObject dialogInterface;

    private List<DialogObject> dialogObjects;

    public void StartDialog(int id)
    {
        Debug.Log("2");

        DialogService dialogService = new DialogService();
        dialogObjects = dialogService.GetDialogObjects(id);

        dialogInterface.SetActive(true);

        StartCoroutine(DialogLoop());
    }

    private IEnumerator DialogLoop()
    {
        foreach(DialogObject dialogObject in dialogObjects)
        {
            PresentText(dialogObject);
            SayLine(); //Empty Call
            yield return new WaitForSeconds(5);

            if (dialogObject.getType().Equals("Dcsn"))
            {
                PresentText(dialogObject);
                SayLine(); //Empty Call
                yield return new WaitForSeconds(5);
            }      
        }
    }

    private void PresentText(DialogObject dialogObject)
    {
        TextMeshProUGUI go = dialogInterface.transform.GetChild(0).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        go.text = dialogObject.getDialogLine();
    }

    private void SayLine()
    {

    }

    private void GetDecision()
    {

    }
}
