using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Pocket
{
    public class CollectRewardQuery:DbSettings,IQuery
    {
        string queryAction = "UPDATE Pocket SET Balance= Balance + @reward WHERE childrenId=@id ";


        SqlConnection conn;

        public CollectRewardQuery()
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
