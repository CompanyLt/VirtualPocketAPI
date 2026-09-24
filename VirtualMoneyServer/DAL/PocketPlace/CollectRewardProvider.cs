using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.PocketPlace
{
    public class CollectRewardProvider:IConnectionService
    {
        IQuery _collectRewardQuery;

        public CollectRewardProvider([FromKeyedServices("CollectRewardQuery")] IQuery collectRewardQuery)
        {
            _collectRewardQuery = collectRewardQuery;


        }

        public SqlConnection GetConnection()
        {
            return _collectRewardQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
            return _collectRewardQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _collectRewardQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }
    }
}
