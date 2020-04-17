using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestjournalDisplay : CloseableMenu
{
    public Questlog questlog;

    public Transform questobjectParent;
    public GameObject questObject;

    public List<Quest> quests;

    public string activeTab = "In Progress";
    public override void Show()
    {
        base.Show();
        ShowQuests("In Progress");
        
    }

    public void ShowQuests(string status)
    {
        quests = questlog.displayByStatus(status);
        foreach (Quest quest in quests)
        {
            Logger.log("" + quest.questName);
            GameObject instance = Instantiate(questObject, questobjectParent);           
            instance.GetComponent<QuestSlot>().Display(quest);
            instance.GetComponent<Button>().onClick.AddListener(() => displayQuestDetails(quest));
        }
    }

    public override void Hide()
    {
        base.Hide();
        HideQuests();
    }

    public void test()
    {
        Logger.log("hsdiasd");
    }

    public void HideQuests()
    {
        Logger.log("" + quests.Count);
        for (int i = 0; i < quests.Count; i++)
        {
            Destroy(questobjectParent.GetChild(i).gameObject);
        }
        quests = null;
    }

    public void filterActiveQuests()
    {
        //quests = questlog.displayByStatus("In Progress");
        /*foreach(Quest quest in quests)
        {
            Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
        }*/
        HideQuests();
        ShowQuests("In Progress");
    }

    public void filterFinishedQuests()
    {
        //questlog.displayByStatus("Finished");
        HideQuests();
        ShowQuests("Finished");
    }

    public void displayQuestDetails(Quest quest)
    {
        //TODO Rechte Seite des QuestJournals
        Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
    }
}
