public class DialogueRepository
{
    public void ReadData() { // just a method for testing
                
    }

    public DialogueObject ReadDialogueObjectById(float id) {
        // Database call


        // Dummy data
        if (id == 1)
        {
            float[] array = {1};
            return new DialogueObject(1, "Line", array);
        } 
        else if (id == 2)
        {
            float[] array = { 2 };
            return new DialogueObject(2, "Line", array);
        } 
        else if (id == 3)
        {
            float[] array = { 3, 4, 5 };
            return new DialogueObject(3, "Decision", array);
        } 
        else if (id == 4)
        {
            float[] array = { 6 };
            return new DialogueObject(4, "Line", array);
        } 
        else if (id == 5)
        {
            float[] array = { 7 };
            return new DialogueObject(5, "Line", array);
        } 
        else if (id == 6)
        {
            float[] array = { 8 };
            return new DialogueObject(6, "Line", array);
        } 
        else
        {
            return new DialogueObject();
        }


    }

    public DialogueLine ReadDialogueLineById(float id)
    {
        // Database call

        // Dummy Data
        if (id == 1)
        {
            return new DialogueLine(1, "Line 1", 2);
        } 
        else if (id == 2)
        {
            return new DialogueLine(2, "Line 2", 3);
        }
        else if (id == 3)
        {
            return new DialogueLine(3, "Decision 1", 2);
        }
        else if (id == 4)
        {
            return new DialogueLine(4, "Decision 2", 2);
        }
        else if (id == 5)
        {
            return new DialogueLine(5, "Decision 3", 2);
        }
        else if (id == 6)
        {
            return new DialogueLine(6, "Line 3", 2);
        }
        else if (id == 6)
        {
            return new DialogueLine(7, "Line 4", 2);
        }
        else if (id == 8)
        {
            return new DialogueLine(8, "Line 5", 2);
        }
        else
        {
            return new DialogueLine();
        }    
    }
}
