using System.Data;

namespace Database
{
    
    public class DialogueClipDb : SqliteHelper
    
    {
        private const string TableName = "DialogueClips";
        private const string KeyId = "id";
        private const string KeyLine = "line";
        private const string KeyClip = "audioclippath";
        private string[] _columns = { KeyId, KeyLine, KeyClip };
        
        /// <summary>
        /// Creates a table for dialog clips if it does not exists.
        /// </summary>
        public DialogueClipDb()
        {
            IDbCommand dbCommand = getDbCommand();
            dbCommand.CommandText =
                $"CREATE TABLE IF NOT EXISTS{TableName}({KeyId} BIGINT PRIMARY KEY, {KeyLine} TEXT, {KeyClip} BIGINT )";
            dbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Inserts a dialog clip in the DB.
        /// </summary>
        /// <param name="dialogClip">The dialog clip to be added.</param>
        public void AddData(DialogClip dialogClip)
        {
            IDbCommand dbCommand = getDbCommand();
            dbCommand.CommandText = $"REPLACE INTO {TableName}({KeyId}, {KeyLine}, {KeyClip}) VALUES (" +
                                    $"'{dialogClip.Id}', '{dialogClip.LineId}', '{dialogClip.Path}')";
            dbCommand.ExecuteNonQuery();
        }

        /// <summary>
        /// Returns a dialog clip from the DB.
        /// </summary>
        /// <param name="id">The id of the dialog clip.</param>
        /// <returns>A dialog clip object</returns>
        public override IDataReader getDataById(int id)
        {
            IDbCommand dbCommand = db_connection.CreateCommand();
            dbCommand.CommandText = $"SELECT * FROM {TableName} WHERE {KeyId} = {id}";
            IDataReader executeReader = dbCommand.ExecuteReader();
            return executeReader;
        }
        
        /// <summary>
        /// Returns a dialog clip from the DB.
        /// </summary>
        /// <param name="id">The id of the dialog line.</param>
        /// <returns>A dialog clip object</returns>
        public IDataReader GetDataByLineId(int id)
        {
            IDbCommand dbCommand = db_connection.CreateCommand();
            dbCommand.CommandText = $"SELECT * FROM {TableName} WHERE {KeyLine} = {id}";
            IDataReader executeReader = dbCommand.ExecuteReader();
            return executeReader;
        }
        
        public override IDataReader getDataByString(string str)
        {
            IDbCommand dbCommand = getDbCommand();
            dbCommand.CommandText =
                $"SELECT * FROM {TableName} WHERE {KeyId} = '{str}'";
            return dbCommand.ExecuteReader();
        }
        
        public override void deleteAllData()
        {
            base.deleteAllData(TableName);
        }

        public override IDataReader getAllData()
        {
            return base.getAllData(TableName);
        }
    }
}
