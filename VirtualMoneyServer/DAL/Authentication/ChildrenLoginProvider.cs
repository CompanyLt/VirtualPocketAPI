using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenLoginProvider:IConnectionService
    {
        IQuery _childrenQuery;


        public ChildrenLoginProvider([FromKeyedServices("ChildrenLoginQuery")] IQuery parentQuery)
        {
            _childrenQuery = parentQuery;
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

          //  _childrenQuery.SetQueryAction("Select id,name,email From ChildrenUser Where name=@userName AND password=@password");

        }
    }
}
