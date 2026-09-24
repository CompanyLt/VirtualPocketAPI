using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskGetProvider : IConnectionService
    {
        IQuery _childrenGetQuery { get; set; }

        public ChildrenTaskGetProvider([FromKeyedServices("ChildrenTaskGetQuery")] IQuery childrenQuery)
        {
            _childrenGetQuery = childrenQuery;
        }

        public SqlConnection GetConnection()
        {
            return _childrenGetQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
           return _childrenGetQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _childrenGetQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }
    }
}
