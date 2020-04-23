using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questMarkerManager : MonoBehaviour
{
    public Questlog questlog;
    public GameObject questMarker;
    void Start()
    {
        
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
        GameObject marker = Instantiate(questMarker);
        //marker.GetComponent<questMarker>().questTarget = quest.activeStage.nextQuestStagesID
    }
}
