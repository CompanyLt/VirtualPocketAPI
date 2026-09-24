using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Tasks
{
    public class TaskCategoryGetQuery : DbSettings, IQuery
    {




        string queryAction = @"Select id,name,image from TaskCategory";


        SqlConnection conn;

        public TaskCategoryGetQuery()
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
