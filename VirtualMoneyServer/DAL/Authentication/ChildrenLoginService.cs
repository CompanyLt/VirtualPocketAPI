using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenLoginService:ILoginService
    {

        IConnectionService _connectionService;

        public ChildrenLoginService([FromKeyedServices("ChildrenRegistrationProvider")] IConnectionService connectionService) 
        { 
        _connectionService = connectionService;
        }



        public async Task<bool> GetUser(LoginModel loginModel)
        {
            await _connectionService.GetConnection().OpenAsync();
            using(SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(),_connectionService.GetConnection()))
            {






            }
            return true;
        }
    }
}
