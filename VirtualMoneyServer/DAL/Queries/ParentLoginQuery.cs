using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries
{
    public class ParentLoginQuery:IQuery
    {
        string dbConnection = @"Data Source=HP-2\SQLEXPRESS;
                                    Initial Catalog=VirtualPocket;
                                    Integrated Security=True;
                                    Connect Timeout=30;Encrypt=False;";


        string queryAction = "Select name,uniqueId FROM ParentUser WHERE name=@name AND password=@password";


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
