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

            DialogClip dialogClip = new DialogClip(id: (int) reader[0], lineId: (int) reader[1], path: reader[2] as string);
            
            dialogueClipDb.close();
            return dialogClip;
        }
    }
}