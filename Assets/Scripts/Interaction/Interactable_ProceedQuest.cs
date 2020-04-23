using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_ProceedQuest : Interactable
{
    public QuestHandler questHandler;
    public Questlog questlog;
    public GameObject questMarker;
    public int interactableId;

    //FUNKTIONSWEISE: Jedes Interactable besitzt eine eindeutige ID, jede QuestStage besitzt ein Array, in dem zu jeder Option x
    //die Quest weiterzuführen eine InteractableID ([x][0]) und die zugehörige nächste Stage ([x][1]) aufgelistet ist
    //Das Interactable durchsucht den gesamten Questlog nach einer Stage, die eine mägliche nächste Stage besitzt, die dieses
    //Interactable ansteuert und ruft die ProceedQuest Methode mit dieser nächsten Stage auf

    public override void interact()
    {
        foreach(Quest quest in questlog.quests.ToArray())   //Es wird über eine Kopie der Liste iteriert, da Probleme auftreten, falls während der Iteration die Quest entfernt wird
        {    
            if(quest.status == "Finished")  //Falls Quest beendet ist, hat sie keine nächste Stufe und muss nicht auf Interaktion gecheckt werden
            {
                return;
            }
            for (int i = 0; i<quest.activeStage.nextQuestStagesID.GetLength(0); i++)
            {
                if (quest.activeStage.nextQuestStagesID[i,0] == interactableId)
                {
                    int nextStageId = quest.activeStage.nextQuestStagesID[i,1];
                    questHandler.ProceedQuest(quest.questId, nextStageId);
                }
            }
        }
    }
}
