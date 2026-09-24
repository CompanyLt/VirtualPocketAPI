using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace VirtualPocket.DAL.Queries.ApiCenter
{
    public class GetApiCommandsQuery:DbSettings,IQuery
    {
        string queryAction = "SELECT * FROM ApiCommands WHERE Id=@apiKey";


        SqlConnection conn;

        public GetApiCommandsQuery()
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
