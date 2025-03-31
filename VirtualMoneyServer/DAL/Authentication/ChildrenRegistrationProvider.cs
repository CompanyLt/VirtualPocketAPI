using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenRegistrationProvider : IConnectionService
    {

        private readonly IQuery _childQuery;


        public ChildrenRegistrationProvider([FromKeyedServices("ChildQuery")] IQuery childQuery)
        {

            _childQuery = childQuery;


        }



        public SqlConnection GetConnection()
        {

            return _childQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _childQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _childQuery.GetQueryAction();
        }

        public void SetQueryAction()
        {

        }


    }
}
