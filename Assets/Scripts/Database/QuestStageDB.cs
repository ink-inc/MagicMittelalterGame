using System;
using System.Data;
using System.Diagnostics;
using System.Linq;

public class QuestStageDB : SqliteHelper
{
    private const string Tag = "Riz: QuestStageDB:\t";

    private const string TABLE_NAME = "QuestStages";
    private const string KEY_ID = "id";
    private const string KEY_TASK = "task";
    private const string KEY_NEXTSTAGEIDS = "nextStageIds";
    private string[] COLUMNS = new string[] { KEY_ID, KEY_TASK, KEY_NEXTSTAGEIDS };

    public QuestStageDB() : base()
    {
        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "CREATE TABLE IF NOT EXISTS " + TABLE_NAME + " ( " +
            KEY_ID + " BIGINT PRIMARY KEY, " +
            KEY_TASK + " TEXT, " +
            KEY_NEXTSTAGEIDS + " TEXT )";
        dbcmd.ExecuteNonQuery();
    }

    public void AddData(QuestStage questStage)
    {
        string nextIds = ""; //TODO: for-Schleife um über jede Zeile der nextStageIds zu iterieren, die beiden Inhalte der Zeile mit Komma trennen und am Ende der Zeile ein Semicolon um die Zeilen zu trennen

        for (int i = 0; i < questStage.nextQuestStagesID.GetLength(0); i++)
        {
            nextIds = nextIds  + questStage.nextQuestStagesID[i, 0] + ";" + questStage.nextQuestStagesID[i, 1] + "%";
            
        }

        IDbCommand dbcmd = getDbCommand();
        dbcmd.CommandText = "REPLACE INTO " + TABLE_NAME + " ( "
            + KEY_ID + ", "
            + KEY_TASK + ", "
            + KEY_NEXTSTAGEIDS + " ) "

            + "VALUES ( '"
            + questStage.stageId + "', '"
            + questStage.task + "', '"
            + nextIds + "' )";
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
