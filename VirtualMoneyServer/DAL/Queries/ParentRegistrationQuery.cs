using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries
{
    public class ParentRegistrationQuery : IQuery
    {

        string dbConnection = @"Data Source=HP-2\SQLEXPRESS;
                                    Initial Catalog=VirtualPocket;
                                    Integrated Security=True;
                                    Connect Timeout=30;Encrypt=False;";


        string query = "Select count(*) FROM ParentUser WHERE mail=@mail";

        SqlConnection conn;

        public ParentRegistrationQuery()
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
            return query;
        }

        public void SetQueryAction(string action)
        {
           query= action;

          
        }
    }
}
