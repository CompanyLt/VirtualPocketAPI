using Microsoft.Data.SqlClient;

namespace VirtualPocket.DAL
{
    public interface IConnectionService
    {



        SqlConnection GetConnection();
        string GetQueryAction();

        void SetConnection(string connection);

        public void SetQueryAction();



    }
}
