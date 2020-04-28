using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestHandler : MonoBehaviour
{
    public Questlog questlog;
    public QuestRepository questRepository;
    public GameObject questUpdate;
    //public QuestMarkerManager markerManager;
    public QuestjournalDisplay journalDisplay;


    public void TryStartQuest(int questId)
    {
        foreach (Quest q in questlog.quests)
        {
            if (q.questId == questId)
            {
                return;
            }
        }
        StartQuest(questId);
    }
    public void StartQuest(int questId)
    {
        Quest quest = questRepository.GiveQuest(questId);
        questlog.StartQuest(quest);
        questlog.MoveToFirst(quest);
        quest.activeStage = quest.firstStage;
        quest.status = "In Progress";
        Logger.log(quest.activeStage.task);
        StartCoroutine(ShowQuest(null,quest.activeStage.task));
        //markerManager.AddMarker(quest);
    }

    public void ProceedQuest(int questId, int nextStageId)
    {

        Quest quest = questlog.GiveQuest(questId);
        string formerTask = quest.activeStage.task;
        QuestStage nextStage = questRepository.GiveStage(nextStageId);
        //markerManager.RemoveMarker(quest);
        string nextTask = nextStage.task;
        quest.passedStages.Add(quest.activeStage);
        quest.activeStage = nextStage;
        Logger.log(quest.activeStage.task);
        if (nextStage.nextQuestStagesID[0,0] == -1)
        {
            StartCoroutine(ShowQuest(formerTask, null));
            FinishQuest(questId);
            return;
        }
        StartCoroutine(ShowQuest(formerTask, nextTask));
        questlog.MoveToFirst(quest);
        //markerManager.AddMarker(quest);
        journalDisplay.ManageMarker(quest);

    }

    private IEnumerator ShowQuest(string formerTask, string newTask)
    {
        questUpdate.SetActive(true);
        if(formerTask != null)
        {
            questUpdate.GetComponent<TextMeshProUGUI>().text = "Completed: " + formerTask;
            yield return new WaitForSeconds(5);
        }       
        if(newTask != null)
        {
            questUpdate.GetComponent<TextMeshProUGUI>().text = "New task: " + newTask;
            yield return new WaitForSeconds(5);
        }
        questUpdate.SetActive(false);

        
    }

    public void FinishQuest(int questId)
    {
        Quest quest = questlog.GiveQuest(questId); 
        Logger.log("Quest Finished");
        quest.status = "Finished";
    }
}
