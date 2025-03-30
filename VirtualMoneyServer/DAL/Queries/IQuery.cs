using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL.Queries
{
    public interface IQuery
    {



        string GetConnection();


        void SetConnection(string connection);


        string GetQueryAction();

        void SetQueryAction(string action);

        SqlConnection GetSqlConnection();




    }
}
