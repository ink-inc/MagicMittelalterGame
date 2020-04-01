using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using UnityEngine;

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
            KEY_DIALOGUELINEIDS + "  )";
    }
}
