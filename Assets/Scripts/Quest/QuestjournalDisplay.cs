﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestjournalDisplay : CloseableMenu
{
    public Questlog questlog;

    public Transform questobjectParent;
    public GameObject questObject;

    public List<Quest> quests;

    public TextMeshProUGUI selectedQuestTask;
    public Transform queststageParent;
    public GameObject questStage;
    public GameObject targetQuestButton;

    public Quest selectedQuest = null;

    private GameObject headline;

    public TMP_InputField searchFor;

    public string searchInput = "";
    public string activeTab = "In Progress";
    public override void Show()
    {
        base.Show();
        ShowQuests("In Progress", searchInput);
        
    }

    public void targetQuest(Quest quest)
    {
        quest.isTargetted = !quest.isTargetted;
        Logger.log(""+quest.isTargetted);
        if (quest.isTargetted)
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Dont target this quest";
        }
        else
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Target this quest";
        }
    }

    public void ShowQuests(string status, string searchFilter)
    {
        quests = questlog.displayByStatus(status, searchFilter);
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
        if (selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
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

    public void HideStages(Quest quest)
    {
        if(headline != null)
        {
            Destroy(headline);
        }
        for(int i = 0; i<quest.passedStages.Count; i++)
        {
            Destroy(queststageParent.GetChild(i+1).gameObject);
        }
        selectedQuestTask.text = "";
        selectedQuest = null;
        targetQuestButton.SetActive(false);
        targetQuestButton.GetComponent<Button>().onClick.RemoveAllListeners();
    }

    public void filterActiveQuests()
    {
        activeTab = "In Progress";
        HideQuests();
        if(selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        ShowQuests("In Progress", searchInput);
    }

    public void filterFinishedQuests()
    {
        activeTab = "Finished";
        HideQuests();
        if (selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        ShowQuests("Finished", searchInput);
    }

    public void filterWithSearchTag()
    {
        searchInput = searchFor.text;
        Logger.log(searchFor.text);
        if(activeTab == "In Progress")
        {
            filterActiveQuests();
        }
        else if(activeTab == "Finished")
        {
            filterFinishedQuests();
        }
    }

    public void displayQuestDetails(Quest quest)
    {
        if (selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        selectedQuest = quest;
        headline = Instantiate(questStage, queststageParent);
        headline.GetComponent<StageSlot>().DisplayHeadline();
        //Button targetter = Instantiate(targetQuestButton);
        targetQuestButton.SetActive(true);
        if (quest.isTargetted)
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Dont target this quest";
        }
        else
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Target this quest";
        }
        targetQuestButton.GetComponent<Button>().onClick.AddListener(() => targetQuest(quest));
        Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
        selectedQuestTask.text = quest.activeStage.task;
        foreach(QuestStage stage in quest.passedStages)
        {
            GameObject instance = Instantiate(questStage, queststageParent);
            instance.GetComponent<StageSlot>().Display(stage);
        }
    }
}