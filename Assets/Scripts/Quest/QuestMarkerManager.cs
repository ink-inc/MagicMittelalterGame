using System.Collections.Generic;
using Interaction;
using UnityEngine;

public class QuestMarkerManager : MonoBehaviour
{
    public Questlog questlog;
    public GameObject questMarker;
    public Transform questInteractables;

    public Transform player;
    public Transform camera;
    public RectTransform compass;

    public Dictionary<int, Transform> interactableList = new Dictionary<int, Transform>();
    void Start()
    {
        
        long firstTime = (System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        for (int i = 0; i<questInteractables.transform.childCount; i++)
        {
            Transform interactable = questInteractables.transform.GetChild(i);
            Logger.log(""+interactable.gameObject.GetComponent<Interactable_ProceedQuest>().interactableId);
            interactableList.Add(interactable.gameObject.GetComponent<Interactable_ProceedQuest>().interactableId, interactable);
        }
        long secondTime = (System.DateTimeOffset.UtcNow.ToUnixTimeMilliseconds());
        Debug.Log(secondTime - firstTime);
    }

    public void AddMarker(Quest quest)
    {
        for(int i= 0; i< quest.activeStage.nextQuestStagesID.GetLength(0); i++)
        {
            AddMarkerToTarget(quest, i);
        }
    }

    public void AddMarkerToTarget(Quest quest, int index)
    {
        GameObject marker = Instantiate(questMarker, compass);
        int interactableId = quest.activeStage.nextQuestStagesID[index,0];
        interactableList.TryGetValue(interactableId, out Transform interactable);
        QuestMarker markerClass = marker.GetComponent<QuestMarker>();
        markerClass.questTarget = interactable;
        markerClass.player = player;
        markerClass.compass = compass;
        markerClass.camera = camera;
        markerClass.targettedStage = quest.activeStage;
    }

    public void RemoveMarker(Quest quest)
    {
        for(int i = 0; i< compass.childCount; i++)
        {
            if(compass.GetChild(i).GetComponent<QuestMarker>() != null)
            {
                if(compass.GetChild(i).GetComponent<QuestMarker>().targettedStage == quest.activeStage)
                {
                    Destroy(compass.GetChild(i).gameObject);
                }
            }
        }
    }
}
