using System.Collections;
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

    public GameObject activeButton;
    public GameObject finishedButton;

    public Quest selectedQuest = null;

    private GameObject _headline;

    public TMP_InputField searchFor;

    public QuestMarkerManager markerManager;

    public string searchInput = "";
    public string activeTab = "In Progress";
    public override void Show()
    {
        base.Show();
        ShowQuests("In Progress", searchInput);
        
    }

    public void TargetQuest(Quest quest)
    {
        quest.isTargetted = !quest.isTargetted;
        Logger.log(""+quest.isTargetted);
        ManageMarker(quest);

    }

    public void ManageMarker(Quest quest)
    {
        if (quest.isTargetted)
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Questmarker not displayed";
            markerManager.RemoveMarker(quest);
        }
        else
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Questmarker displayed";
            markerManager.AddMarker(quest);
        }
    }

    public void ShowQuests(string status, string searchFilter)
    {
        quests = questlog.DisplayByStatus(status, searchFilter);
        foreach (Quest quest in quests)
        {
            Logger.log("" + quest.questName);
            GameObject instance = Instantiate(questObject, questobjectParent);           
            instance.GetComponent<QuestSlot>().Display(quest);
            instance.GetComponent<Button>().onClick.AddListener(() => DisplayQuestDetails(quest));
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
        if(_headline != null)
        {
            Destroy(_headline);
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

    public void FilterActiveQuests()
    {
        activeTab = "In Progress";
        HideQuests();
        if(selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        ShowQuests("In Progress", searchInput);
        Color color;
        ColorUtility.TryParseHtmlString("524332", out color);
        activeButton.GetComponent<Image>().color = new Color32(82, 67, 50, 255);
        ColorUtility.TryParseHtmlString("E7B993", out color);
        finishedButton.GetComponent<Image>().color = new Color32(231, 185, 147, 255);
    }

    public void FilterFinishedQuests()
    {
        activeTab = "Finished";
        HideQuests();
        if (selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        ShowQuests("Finished", searchInput);
        Color color;
        ColorUtility.TryParseHtmlString("524332", out color);
        finishedButton.GetComponent<Image>().color = new Color32(82, 67, 50,255);
        ColorUtility.TryParseHtmlString("E7B993", out color);
        activeButton.GetComponent<Image>().color = new Color32(231, 185, 147, 255);
    }

    public void FilterWithSearchTag()
    {
        searchInput = searchFor.text;
        Logger.log(searchFor.text);
        if(activeTab == "In Progress")
        {
            FilterActiveQuests();
        }
        else if(activeTab == "Finished")
        {
            FilterFinishedQuests();
        }
    }

    public void DisplayQuestDetails(Quest quest)
    {
        if (selectedQuest != null)
        {
            HideStages(selectedQuest);
        }
        selectedQuest = quest;
        _headline = Instantiate(questStage, queststageParent);
        _headline.GetComponent<StageSlot>().DisplayHeadline();
        if(activeTab == "In Progress")
        {
            targetQuestButton.SetActive(true);
        }
        
        if (quest.isTargetted)
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Questmarker not displayed";
        }
        else
        {
            targetQuestButton.GetComponentInChildren<Text>().text = "Questmarker displayed";
        }
        targetQuestButton.GetComponent<Button>().onClick.AddListener(() => TargetQuest(quest));
        Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
        selectedQuestTask.text = quest.activeStage.task;
        foreach(QuestStage stage in quest.passedStages)
        {
            GameObject instance = Instantiate(questStage, queststageParent);
            instance.GetComponent<StageSlot>().Display(stage);
        }
    }
}
