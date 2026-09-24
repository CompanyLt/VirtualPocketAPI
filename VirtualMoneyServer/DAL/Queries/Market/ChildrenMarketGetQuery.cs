using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace VirtualPocket.DAL.Queries.Market
{
    public class ChildrenMarketGetQuery:DbSettings,IQuery
    {




        string queryAction = "Select id,title,description,category,price,assign,status FROM Market WHERE assign=@uniqueId";


        SqlConnection conn;

        public ChildrenMarketGetQuery()
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
