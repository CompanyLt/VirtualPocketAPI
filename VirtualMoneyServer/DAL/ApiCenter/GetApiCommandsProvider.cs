using Microsoft.Data.SqlClient;
using VirtualPocket.DAL.Queries;

namespace VirtualPocket.DAL.ApiCenter
{
    public class GetApiCommandsProvider:IConnectionService
    {

        IQuery _getApiCommandsQuery;

        public GetApiCommandsProvider([FromKeyedServices("GetApiCommandsQuery")] IQuery getApiCommandsQuery)
        {
            _getApiCommandsQuery = getApiCommandsQuery;
        }

        public SqlConnection GetConnection()
        {

            return _getApiCommandsQuery.GetSqlConnection();
        }

        public void SetConnection(string connection)
        {
            _getApiCommandsQuery.SetConnection(connection);
        }


        public string GetQueryAction()
        {
            return _getApiCommandsQuery.GetQueryAction();
        }

        public void SetQueryAction()
        {
            _getApiCommandsQuery.SetQueryAction("INSERT INTO ChildrenUser(name,surename,username,password,email) OUTPUT INSERTED.id VALUES(@name,@surename,@username, @password, @email)");
        }


    }
}
