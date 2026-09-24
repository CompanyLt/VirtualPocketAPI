using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskSetProvider:IConnectionService
    {
        IQuery _childrenQuery;


        public ChildrenTaskSetProvider([FromKeyedServices("ChildrenTaskSetQuery")] IQuery childrenGetQuery)
        {
            _childrenQuery = childrenGetQuery;
        }


        public SqlConnection GetConnection()
        {

            return _childrenQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _childrenQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _childrenQuery.GetQueryAction();
        }


        public void SetQueryAction()
        {

            _childrenQuery.SetQueryAction("INSERT INTO TaskCategoryAssignments(taskId,categoryId) VALUES(@taskId,@categoryId)");

        }




    }
}

