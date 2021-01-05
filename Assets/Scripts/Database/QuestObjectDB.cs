using System;
using System.Data;
using System.Linq;

public class QuestObjectDB : SqliteHelper
{
    private const string Tag = "Riz: QuestObjectDB:\t";

    private const string TABLE_NAME = "Quests";
    private const string KEY_ID = "id";
    private const string KEY_NAME = "name";
    private const string KEY_FIRSTSTAGEID = "firstStageId";
    private string[] COLUMNS = new string[] { KEY_ID, KEY_NAME, KEY_FIRSTSTAGEID };

    public QuestObjectDB() : base()
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
            KEY_ID + " BIGINT PRIMARY KEY, " +
            KEY_NAME + " TEXT, " +
            KEY_FIRSTSTAGEID + " BIGINT )";
        dbcmd.ExecuteNonQuery();
    }

    public void AddData(Quest quest)
    {

        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "REPLACE INTO " + TABLE_NAME + " ( "
            + KEY_ID + ", "
            + KEY_NAME + ", "
            + KEY_FIRSTSTAGEID + " ) "

            + "VALUES ( '"
            + quest.questId + "', '"
            + quest.questName + "', '"
            + quest.firstStage.stageId + "' )";
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
