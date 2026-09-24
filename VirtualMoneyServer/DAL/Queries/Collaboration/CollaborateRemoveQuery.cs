using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Collaboration
{
    public class CollaborateRemoveQuery : DbSettings, IQuery
    {
        string queryAction = "DELETE FROM Collaborate WHERE childrenId=@childrenId AND parentId=@parentId";


        SqlConnection conn;

        public CollaborateRemoveQuery()
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
