using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.PocketPlace
{
    public class GetPocketProvider:IConnectionService
    {
        IQuery _getPocketQuery;

        public GetPocketProvider([FromKeyedServices("GetPocketQuery")] IQuery getPocketQuery)
        {
            _getPocketQuery = getPocketQuery;


        }

        public SqlConnection GetConnection()
        {
            return _getPocketQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
            return _getPocketQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _getPocketQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }

    }
}
