using System.Data;
using Database;

namespace Dialogue
{
    public class DialogueClipRepository
    {
        public DialogClip GetDialogClipByLineId(int id)
        {
            DialogueClipDb dialogueClipDb = new DialogueClipDb();
            IDataReader reader = dialogueClipDb.GetDataByLineId(id);
            
            int itemId = int.Parse($"{reader[0]}");
            int lineId = int.Parse($"{reader[1]}");
            string path = $"{reader[2]}";
            DialogClip dialogClip = new DialogClip(id: itemId, lineId: lineId, path: path);
            
            dialogueClipDb.close();
            return dialogClip;
        }
    }
}