using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Market
{
    public class ChildrenMarketGetProvider:IConnectionService
    {

        IQuery _childrenMarketGetQuery;

        public ChildrenMarketGetProvider([FromKeyedServices("ChildrenMarketGetQuery")]IQuery childrenMarketGetQuery)
        {
            _childrenMarketGetQuery = childrenMarketGetQuery;


        }

        public SqlConnection GetConnection()
        {
           return _childrenMarketGetQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
           return _childrenMarketGetQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _childrenMarketGetQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }
    }
}

