using TMPro;
using UnityEngine;

namespace Quest
{
    public class QuestSlot : MonoBehaviour
    {
        public TextMeshProUGUI questName;
        public void Display(Quest quest)
        {
            questName.text = quest.questName;
        }
    }
}
