using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Pocket
{
    public class GetPocketQuery:DbSettings,IQuery
    {

        string queryAction = "SELECT id,balance FROM Pocket WHERE childrenId=@id";


        SqlConnection conn;

        public GetPocketQuery()
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
