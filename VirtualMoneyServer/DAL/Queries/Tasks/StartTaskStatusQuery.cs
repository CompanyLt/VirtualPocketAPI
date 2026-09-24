using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace VirtualPocket.DAL.Queries.Tasks
{
    public class StartTaskStatusQuery:DbSettings,IQuery
    {



        string queryAction = "UPDATE Tasks SET status=@status WHERE id=@id";
   


        SqlConnection conn;

        public StartTaskStatusQuery()
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
