using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace VirtualPocket.DAL.Queries.Collaboration
{
    public class ChildrenGetQuery : DbSettings, IQuery
    {
        string queryAction = @"Select       
        ch.name,
        ch.id
        FROM
        Collaborate c
        LEFT JOIN 
        ChildrenUser ch ON c.childrenId=ch.id
        WHERE c.parentId = @id
        

";


        SqlConnection conn;

        public ChildrenGetQuery()
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
