public class DialogueLine
{
    public float lineId { get; set; }
    public string line { get; set; }
    public float nextDialogueObjectId { get; set; }

    public DialogueLine() { }

    public DialogueLine(float lineId, string line, float nextDialogueObjectId)
    {
        this.lineId = lineId;
        this.line = line;
        this.nextDialogueObjectId = nextDialogueObjectId;
    }
}
