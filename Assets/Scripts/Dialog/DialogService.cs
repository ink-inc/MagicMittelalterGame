using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogService
{
    private DialogRepository dialogRepository = new DialogRepository();
    public List<DialogObject> GetDialogObjects(int id)
    {
        string path = "TestDialog.txt";

        return dialogRepository.ReadData(path);
    }
}
