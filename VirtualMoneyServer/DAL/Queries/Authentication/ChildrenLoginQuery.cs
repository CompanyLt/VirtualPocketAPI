using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace VirtualPocket.DAL.Queries.Authentication
{
    public class ChildrenLoginQuery : DbSettings, IQuery
    {


        string queryAction = "Select name,username,id,avatar FROM ChildrenUser WHERE username=@username AND password=@password";


        SqlConnection conn;

        public ChildrenLoginQuery()
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
