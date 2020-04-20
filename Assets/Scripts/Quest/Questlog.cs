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

    public void moveToFirst(Quest quest)
    {
        quests.Remove(quest);
        quests.Insert(0, quest);
    }

    public Quest giveQuest(int questId) //Search questlog for a quest using a questId
    {
        foreach (Quest quest in quests)
        {
            if (quest.questId == questId)
            {
                return quest;
            }
        }
        throw new DataException("Quest not found in questlog");
    }

    public void displayQuests(/*string name*/)  //name is result of search bar. If the player doesnt search, name is NULL
    {
        foreach (Quest quest in quests)
        {
            Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
        }
    }

    public List<Quest> displayByStatus(string status, string searchFilter)
    {
        List<Quest> questList = new List<Quest>();
        foreach (Quest quest in quests)
        {
            if (status == quest.status && (quest.questName.ToLower().Contains(searchFilter.ToLower()) || searchFilter == ""))
            {
                questList.Add(quest);
            }
        }
        return questList;
    }
}