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
            return new DialogueObject(id, "Line", array);
        } 
        else if (id == 2)
        {
            float[] array = { 2 };
            return new DialogueObject(id, "Line", array);
        } 
        else if (id == 3)
        {
            float[] array = { 3, 4, 5 };
            return new DialogueObject(id, "Decision", array);
        } 
        else if (id == 4)
        {
            float[] array = { 6 };
            return new DialogueObject(id, "Line", array);
        } 
        else if (id == 5)
        {
            float[] array = { 7 };
            return new DialogueObject(id, "Line", array);
        } 
        else if (id == 6)
        {
            float[] array = { 8 };
            return new DialogueObject(id, "Line", array);
        } 
        else if (id == 7)
        {
            float[] array = { };
            return new DialogueObject(id, "End", array);
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
            return new DialogueLine(3, "Decision 1", 4);
        }
        else if (id == 4)
        {
            return new DialogueLine(4, "Decision 2", 5);
        }
        else if (id == 5)
        {
            return new DialogueLine(5, "Decision 3", 6);
        }
        else if (id == 6)
        {
            return new DialogueLine(6, "Line 6", 7);
        }
        else if (id == 7)
        {
            return new DialogueLine(7, "Line 7", 7);
        }
        else if (id == 8)
        {
            return new DialogueLine(8, "Line 8", 7);
        }
        else
        {
            return new DialogueLine();
        }    
    }
}
