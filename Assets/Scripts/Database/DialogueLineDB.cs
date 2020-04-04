using System.Data;
public class DialogueLineDB : SqliteHelper
{
    private const string Tag = "Riz: DialogueLineDB:\t";

    private const string TABLE_NAME = "DialogueLines";
    private const string KEY_ID = "id";
    private const string KEY_LINE = "line";
    private const string KEY_NEXTDIALOGUEOBJECTID = "nextDialogueObjectId";
    private string[] COLUMNS = new string[] { KEY_ID, KEY_LINE, KEY_NEXTDIALOGUEOBJECTID };

    public DialogueLineDB() : base()
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
            KEY_ID + " BIGINT PRIMARY KEY, " +
            KEY_LINE + " TEXT, " +
            KEY_NEXTDIALOGUEOBJECTID + " BIGINT )";
        dbcmd.ExecuteNonQuery();
    }

    public void AddData(DialogueLine dialogueLine)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "REPLACE INTO " + TABLE_NAME + " ( "
            + KEY_ID + ", "
            + KEY_LINE + ", "
            + KEY_NEXTDIALOGUEOBJECTID + " ) "

            + "VALUES ( '"
            + dialogueLine.lineId + "', '"
            + dialogueLine.line + "', '"
            + dialogueLine.nextDialogueObjectId + "' )";
        dbcmd.ExecuteNonQuery();
    }

    public override IDataReader getDataById(int id)
    {
        IDbCommand dbcmd = db_connection.CreateCommand();
        dbcmd.CommandText =
            "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = " + id;
        IDataReader reader = dbcmd.ExecuteReader();
        return reader;
    }

    public override IDataReader getDataByString(string str)
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText =
            "SELECT * FROM " + TABLE_NAME + " WHERE " + KEY_ID + " = '" + str + "'";
        return dbcmd.ExecuteReader();
    }

    public override void deleteDataById(int id)
    {
        base.deleteDataById(id);
    }

    public override void deleteAllData()
    {
        base.deleteAllData(TABLE_NAME);
    }

    public override IDataReader getAllData()
    {
        return base.getAllData(TABLE_NAME);
    }
}