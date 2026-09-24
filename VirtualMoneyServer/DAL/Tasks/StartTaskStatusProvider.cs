using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Tasks
{
    public class StartTaskStatusProvider : IConnectionService
    {
        IQuery _childrenGetQuery { get; set; }

        public StartTaskStatusProvider([FromKeyedServices("StartTaskStatusQuery")] IQuery startTaskStatusQuery)
        {
            _childrenGetQuery = startTaskStatusQuery;
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
