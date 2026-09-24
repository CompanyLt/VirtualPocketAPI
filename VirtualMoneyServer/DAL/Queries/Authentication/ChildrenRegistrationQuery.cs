using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Authentication
{
    public class ChildrenRegistrationQuery : DbSettings, IQuery
    {


        string queryAction = "SELECT CASE WHEN EXISTS(Select 1 FROM ChildrenUser WHERE email=@email AND username=@username) OR EXISTS(SELECT 1 FROM ParentUser WHERE mail=@email AND username=@username) THEN 1 ELSE 0 END";

        SqlConnection conn;

        public ChildrenRegistrationQuery()
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
