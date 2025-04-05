using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries
{
    public class ChildrenGetQuery: DbSettings, IQuery
    {
        string queryAction = "Select name,id FROM ChildrenUser WHERE name=@name AND password=@password";


        SqlConnection conn;

        public ChildrenGetQuery()
        {
            conn = new SqlConnection(dbConnection);
        }

        public string GetConnection()
        {
            return dbConnection;
        }

        public SqlConnection GetSqlConnection() { return conn; }


        public void SetConnection(string connection)
        {
            dbConnection = connection;
        }


        public string GetQueryAction()
        {
            return queryAction;
        }

        public void SetQueryAction(string action)
        {
            queryAction = action;
        }
    }
}
