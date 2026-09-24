using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Authentication
{
    public class ParentLoginQuery : DbSettings, IQuery
    {



        string queryAction = "Select name,username,id FROM ParentUser WHERE username=@username AND password=@password";


        SqlConnection conn;

        public ParentLoginQuery()
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
