using UnityEngine;

public class DBTest : MonoBehaviour
{
    void Start()
    {
        DialogueLineDB dialogueLineDB1 = new DialogueLineDB();

        dialogueLineDB1.AddData(new DialogueLine(1, "Line 1", 2));
        dialogueLineDB1.AddData(new DialogueLine(2, "Line 2", 3));
        dialogueLineDB1.AddData(new DialogueLine(3, "Decision 1", 4));
        dialogueLineDB1.AddData(new DialogueLine(4, "Decision 2", 5));
        dialogueLineDB1.AddData(new DialogueLine(5, "Decision 3", 6));
        dialogueLineDB1.AddData(new DialogueLine(6, "Line 6", 7));
        dialogueLineDB1.AddData(new DialogueLine(7, "Line 7", 7));
        dialogueLineDB1.AddData(new DialogueLine(8, "Line 8", 7));
        
        dialogueLineDB1.close();


        DialogueObjectDB dialogueObjectDB1 = new DialogueObjectDB();
        int[] array1 = { 1 };
        dialogueObjectDB1.AddData(new DialogueObject(1, "Line", array1));
        int[] array2 = { 2 };
        dialogueObjectDB1.AddData(new DialogueObject(2, "Line", array2));
        int[] array3 = { 3, 4, 5 };
        dialogueObjectDB1.AddData(new DialogueObject(3, "Decision", array3));
        int[] array4 = { 6 };
        dialogueObjectDB1.AddData(new DialogueObject(4, "Line", array4));
        int[] array5 = { 7 };
        dialogueObjectDB1.AddData(new DialogueObject(5, "Line", array5));
        int[] array6 = { 8 };
        dialogueObjectDB1.AddData(new DialogueObject(6, "Line", array6));
        int[] array7 = { };
        dialogueObjectDB1.AddData(new DialogueObject(7, "End", array7));
 
        dialogueObjectDB1.close();
    }
}
