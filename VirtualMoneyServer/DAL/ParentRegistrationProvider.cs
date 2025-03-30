using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL
{
    public class ParentRegistrationProvider:IConnectionService
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
            
            _parentQuery.SetQueryAction("INSERT INTO ParentUser(name,password,mail,uniqueId,phoneNumber) VALUES(@name, @password, @mail, @uniqueId, @phoneNumber)");

        }
    }
}
