using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL
{
    public class ChildrenConnectionService:IConnectionService
    {

        private readonly IQuery _childQuery;


        public ChildrenConnectionService([FromKeyedServices("ChildQuery")]IQuery childQuery) { 
        
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
