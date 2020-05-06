using TMPro;
using UnityEngine;

public class QuestSlot : MonoBehaviour
{
    public TextMeshProUGUI questName;
    public void Display(Quest quest)
    {
        this.questName.text = quest.questName;
    }
}
