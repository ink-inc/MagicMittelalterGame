using TMPro;
using UnityEngine;

namespace Quest
{
    public class QuestSlot : MonoBehaviour
    {
        public TextMeshProUGUI questName;
        public void Display(global::Quest.Quest quest)
        {
            this.questName.text = quest.questName;
        }
    }
}
