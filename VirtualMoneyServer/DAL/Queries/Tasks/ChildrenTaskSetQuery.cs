using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Tasks
{
    public class ChildrenTaskSetQuery : DbSettings, IQuery
    {



        string queryAction = "INSERT INTO Tasks(title,description,status,reward,createTime,assign) OUTPUT INSERTED.id VALUES(@title,@description,@status,@reward,GETDATE(),@assignId)";


        SqlConnection conn;

        public ChildrenTaskSetQuery()
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
