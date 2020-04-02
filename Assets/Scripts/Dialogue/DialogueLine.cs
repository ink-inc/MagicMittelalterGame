public class DialogueLine
{
    public int lineId { get; set; }
    public string line { get; set; }
    public int nextDialogueObjectId { get; set; }

    public DialogueLine() { }

    public DialogueLine(int lineId, string line, int nextDialogueObjectId)
    {
        this.lineId = lineId;
        this.line = line;
        this.nextDialogueObjectId = nextDialogueObjectId;
    }
}
