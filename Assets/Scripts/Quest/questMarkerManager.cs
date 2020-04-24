using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questMarkerManager : MonoBehaviour
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

    public void addMarker(Quest quest)
    {
        for(int i= 0; i< quest.activeStage.nextQuestStagesID.GetLength(0); i++)
        {
            addMarkerToTarget(quest, i);
        }
    }

    public void addMarkerToTarget(Quest quest, int index)
    {
        GameObject marker = Instantiate(questMarker, compass);
        int interactableId = quest.activeStage.nextQuestStagesID[index,0];
        interactableList.TryGetValue(interactableId, out Transform interactable);
        marker.GetComponent<questMarker>().questTarget = interactable;
        marker.GetComponent<questMarker>().player = player;
        marker.GetComponent<questMarker>().compass = compass;
        marker.GetComponent<questMarker>().camera = camera;
        marker.GetComponent<questMarker>().targettedStage = quest.activeStage;
    }

    public void removeMarker(Quest quest)
    {
        for(int i = 0; i< compass.childCount; i++)
        {
            if(compass.GetChild(i).GetComponent<questMarker>() != null)
            {
                if(compass.GetChild(i).GetComponent<questMarker>().targettedStage == quest.activeStage)
                {
                    Destroy(compass.GetChild(i).gameObject);
                }
            }
        }
    }
}
