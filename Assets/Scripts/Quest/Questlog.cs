using System.Collections.Generic;
using System.Data;
using UnityEngine;

namespace Quest
{
    public class Questlog : MonoBehaviour
    {
        public List<global::Quest.Quest> quests = new List<global::Quest.Quest>();

        public void StartQuest(global::Quest.Quest quest) // Adds started quest to the list of quests, the player currently has
        {
            quests.Add(quest);
        }

        public void FinishQuest(global::Quest.Quest quest) // Removes quest after finishing (or failing?) said quest
        {
            quests.Remove(quest);
        }

        public void MoveToFirst(global::Quest.Quest quest)
        {
            quests.Remove(quest);
            quests.Insert(0, quest);
        }

        public global::Quest.Quest GiveQuest(int questId) // Search questlog for a quest using a questId
        {
            foreach (global::Quest.Quest quest in quests)
            {
                if (quest.questId == questId)
                {
                    return quest;
                }
            }
            throw new DataException("Quest not found in questlog");
        }

        public void DisplayQuests()  // name is result of search bar. If the player doesnt search, name is NULL
        {
            foreach (global::Quest.Quest quest in quests)
            {
                Logger.log("Quest:" + quest.questName + " mit ID " + quest.questId + ", Status: " + quest.status);
            }
        }

        public List<global::Quest.Quest> DisplayByStatus(string status, string searchFilter)
        {
            List<global::Quest.Quest> questList = new List<global::Quest.Quest>();
            foreach (global::Quest.Quest quest in quests)
            {
                if (status == quest.status && (quest.questName.ToLower().Contains(searchFilter.ToLower()) || quest.activeStage.task.ToLower().Contains(searchFilter.ToLower()) || searchFilter == ""))
                {
                    questList.Add(quest);
                }
            }
            return questList;
        }
    }
}