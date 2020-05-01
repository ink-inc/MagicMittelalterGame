using TMPro;
using UnityEngine;

namespace Quest
{
    public class StageSlot : MonoBehaviour
    {
        public TextMeshProUGUI stageTask;
        public void Display(QuestStage stage)
        {
            this.stageTask.text = stage.task;
        }

        public void DisplayHeadline()
        {
            this.stageTask.text = "Finished tasks:";
        }
    }
}
