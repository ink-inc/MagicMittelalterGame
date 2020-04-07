using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questlog : MonoBehaviour
{
    public List<Quest> quests;

    public void StartQuest(Quest quest) //Adds started quest to the list of quests, the player currently has
    {
        quests.Add(quest);
    }

    public void FinishQuest(Quest quest) //Removes quest after finishing (or failing?) said quest
    {
        quests.Remove(quest);
    }
}
