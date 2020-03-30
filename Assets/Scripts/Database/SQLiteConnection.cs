using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;

public class SQLiteConnection : MonoBehaviour
{
    void Start()
    {
        // Create database
        string connection = "URI=file:" + Application.persistentDataPath + "/My_Database";

        // Open connection
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        // Create table
        IDbCommand dbcmd;
        dbcmd = dbcon.CreateCommand();
        string q_createTable = "CREATE TABLE IF NOT EXISTS my_table (id INTEGER PRIMARY KEY, val INTEGER )";

        dbcmd.CommandText = q_createTable;
        dbcmd.ExecuteReader();

        // Inser values in table
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO my_table (id, val) VALUES (1, 5)";
        cmnd.ExecuteNonQuery();

        // Read and print all values in table
        IDbCommand cmnd_read = dbcon.CreateCommand();
        IDataReader reader; 
        string query = "SELECT * FROM my_table";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader(); 
        
        while (reader.Read())
        {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("val: " + reader[1].ToString());
        }

        //Close connection
        dbcon.Close();
    }

    void Update()
    {
        
    }
}
