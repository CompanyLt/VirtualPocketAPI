using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Tasks
{
    public class TaskCategoryGetProvider:IConnectionService
    {

        IQuery _taskCategoryGetQuery { get; set; }

        public TaskCategoryGetProvider([FromKeyedServices("TaskCategoryGetQuery")] IQuery taskCategoryGetQuery)
        {
            _taskCategoryGetQuery = taskCategoryGetQuery;
        }

        public SqlConnection GetConnection()
        {
            return _taskCategoryGetQuery.GetSqlConnection();
        }

        public string GetQueryAction()
        {
            return _taskCategoryGetQuery.GetQueryAction();
        }

        public void SetConnection(string connection)
        {
            _taskCategoryGetQuery.SetConnection(connection);
        }

        public void SetQueryAction()
        {
            throw new NotImplementedException();
        }



    }
}
