using System;
using System.Data;
using System.Linq;

public class DialogueObjectDB : SqliteHelper
{
    private const string Tag = "Riz: DialogueObjectDB:\t";

    private const string TABLE_NAME = "DialogueObjects";
    private const string KEY_ID = "id";
    private const string KEY_TYPE = "type";
    private const string KEY_DIALOGUELINEIDS = "dialogueLineIds";
    private string[] COLUMNS = new string[] { KEY_ID, KEY_TYPE, KEY_DIALOGUELINEIDS };

    public DialogueObjectDB() : base()
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
            KEY_ID + " BIGINT PRIMARY KEY, " +
            KEY_TYPE + " TEXT, " +
            KEY_DIALOGUELINEIDS + " TEXT )";
        dbcmd.ExecuteNonQuery();
    }

    public void AddData (DialogueObject dialogueObject)
    {
        string ids = String.Join(",", dialogueObject.dialogueLineIds.Select(p => p.ToString()).ToArray());

        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "REPLACE INTO " + TABLE_NAME + " ( "
            + KEY_ID + ", "
            + KEY_TYPE + ", "
            + KEY_DIALOGUELINEIDS + " ) "

            + "VALUES ( '"
            + dialogueObject.id + "', '"
            + dialogueObject.type + "', '"
            + ids + "' )";
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
