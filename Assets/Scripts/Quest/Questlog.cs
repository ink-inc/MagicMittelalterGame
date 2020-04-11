using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public class Questlog : MonoBehaviour
{
    public List<Quest> quests = new List<Quest>();

    public void StartQuest(Quest quest) //Adds started quest to the list of quests, the player currently has
    {
        quests.Add(quest);
    }

    public void FinishQuest(Quest quest) //Removes quest after finishing (or failing?) said quest
    {
        quests.Remove(quest);
    }

    public Quest giveQuest(int questId) //Search questlog for a quest using a questId
    {
        foreach(Quest quest in quests)
        {
            if(quest.questId == questId)
            {
                return quest;
            }
        }
        throw new DataException("Quest not found in questlog");
    }
}
