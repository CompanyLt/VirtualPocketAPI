using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries.Market
{
    public class ChildrenMarketSetQuery: DbSettings, IQuery
    {


        string queryAction = @"INSERT INTO Market (title, description, price, category, assign, status) 
                      VALUES (@title, @description, @price, @category, @assign, @status)";


        SqlConnection conn;

        public ChildrenMarketSetQuery()
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
