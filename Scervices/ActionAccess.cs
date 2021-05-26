using System.Data.OleDb;

namespace SQLDemo.access.Scervices
{
    public class ActionAccess
    {
        private OleDbDataAdapter _dataAdapter;
        private OleDbTransaction _dbTransaction;
        public OleDbDataAdapter DataAdapter { get { return _dataAdapter; } set { _dataAdapter = value; } }
        public OleDbTransaction DbTransaction { get { return _dbTransaction; } set { _dbTransaction = value; } }

        private OleDbConnection _dbConnection;
        internal OleDbConnection DbConnection
        {
            get
            {
                if (_dbConnection == null)
                {
                    this.InitConnection();
                }
                return _dbConnection;
            }
        }

        private OleDbCommand _dbCommand;
        internal OleDbCommand DbCommand
        {
            get
            {
                if (_dbCommand == null)
                {
                    this.InitCommand();
                }
                return _dbCommand;

            }
        }

        private string _queryString;
        public string QueryString
        {
            get
            {
                return _queryString;
            }

            set
            {
                _queryString = value;
            }
        }


        private void InitConnection()
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\DataBase.accdb;Persist Security Info=True";
            this._dbConnection = new OleDbConnection(connectionString);
        }
        private void InitCommand()
        {

            this._dbCommand = new OleDbCommand(QueryString, this.DbConnection);
        }
        public void SqlReadAction() { }
        public void SqlReadAction(string TableName) { }
        public void SqlReadAction(string TableName, string Item) { }
        public object[] SqlReadAction(string TableName, string Item, string ItemName)
        {
            object[] info = new object[10];
            this.InitConnection();
            QueryString = "SELECT *FROM " + TableName + " where " + Item + "=" + "'" + ItemName + "'";
            this.InitCommand();

            this._dbConnection.Open();
            OleDbDataReader reader = this._dbCommand.ExecuteReader();
            while (reader.Read())
            {
                reader.GetValues(info);
            }
            // always call Close when done reading.
            reader.Close();
            return info;
        }

        public virtual void DeleteAction(string TableName, string condition) { }
        public virtual void WriteAction<T>(string TableName, string IndexName, T param) { }
        public  void InsertAction<T>(string TableName, string Item, T param)
        {
            this.InitConnection();
            this._dbConnection.Open();
            QueryString = "INSERT INTO " + TableName + "(" + Item + ")"+"VALUES" + "(" + param + ")";
            this.InitCommand();
            this._dbCommand.ExecuteNonQuery();
            this._dbConnection.Close();
        }
        public virtual void UpDate<T>(string TableName, string IndexName, T param, string condition) { }

    }
}
