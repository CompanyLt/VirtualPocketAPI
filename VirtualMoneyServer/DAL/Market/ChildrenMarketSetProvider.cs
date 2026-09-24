using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Market
{
    public class ChildrenMarketSetProvider : IConnectionService
    {

        IQuery _childrenMarketSetQuery;


        public ChildrenMarketSetProvider([FromKeyedServices("ChildrenMarketSetQuery")] IQuery childrenMarketSetQuery)
        {
            _childrenMarketSetQuery = childrenMarketSetQuery;
        }
        public SqlConnection GetConnection()
        {
            return _childrenMarketSetQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
            return _childrenMarketSetQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _childrenMarketSetQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }
    }
}
