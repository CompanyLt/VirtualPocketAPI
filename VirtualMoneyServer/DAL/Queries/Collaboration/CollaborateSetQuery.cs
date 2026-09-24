using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Collaboration
{
    public class CollaborateSetQuery : DbSettings, IQuery
    {
        string queryAction = @"
            SELECT * FROM ChildrenUser WHERE id=@id             
            AND NOT EXISTS(
               SELECT 1 FROM Collaborate WHERE childrenId=@id
                    )
         


 ";


        SqlConnection conn;

        public CollaborateSetQuery()
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
