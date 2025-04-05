using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries
{
    public class ChildrenTaskSetQuery: DbSettings, IQuery
    {
       


        string queryAction = "Select count(*) FROM ChildrenUser WHERE email=@email";


        SqlConnection conn;

        public ChildrenTaskSetQuery()
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
