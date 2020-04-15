using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestjournalDisplay : CloseableMenu
{
    public Questlog questlog;
    public override void Show()
    {
        base.Show();
    }

    public void filterActiveQuests()
    {
        questlog.displayByStatus("In Progress");
    }

    public void filterFinishedQuests()
    {
        questlog.displayByStatus("Finished");
    }
}
