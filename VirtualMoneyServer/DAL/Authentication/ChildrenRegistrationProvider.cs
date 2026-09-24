using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenRegistrationProvider : IConnectionService
    {

        private readonly IQuery _childrenQuery;


        public ChildrenRegistrationProvider([FromKeyedServices("ChildrenRegistrationQuery")] IQuery childQuery)
        {

            _childrenQuery = childQuery;


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
            _childrenQuery.SetQueryAction("INSERT INTO ChildrenUser(name,surename,username,password,email) OUTPUT INSERTED.id VALUES(@name,@surename,@username, @password, @email)");
        }


    }
}
