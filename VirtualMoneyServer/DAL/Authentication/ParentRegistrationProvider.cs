using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.Authentication
{
    public class ParentRegistrationProvider : IConnectionService
    {
        IQuery _parentQuery;


        public ParentRegistrationProvider([FromKeyedServices("ParentRegistrationQuery")] IQuery parentQuery)
        {
            _parentQuery = parentQuery;
        }


        public SqlConnection GetConnection()
        {

            return _parentQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _parentQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _parentQuery.GetQueryAction();
        }


        public void SetQueryAction()
        {

            _parentQuery.SetQueryAction("INSERT INTO ParentUser(name,surename,username,password,mail) OUTPUT INSERTED.id VALUES(@name,@surename,@username, @password, @email)");

        }
    }
}
