using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Tasks
{
    public class ChildrenTaskGetQuery : DbSettings, IQuery
    {




        string queryAction = @"Select 
            t.*,
            tca.categoryId
            FROM
            Tasks t
            LEFT JOIN TaskCategoryAssignments tca ON t.id = tca.taskId
            WHERE 
            t.assign = @assignId 
            AND t.status != 'CLOSED' AND t.status !='CANCELED'
        ";


        SqlConnection conn;

        public ChildrenTaskGetQuery()
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
