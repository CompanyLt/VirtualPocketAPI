using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenLoginService:ILoginService
    {

        IConnectionService _connectionService;

        public ChildrenLoginService([FromKeyedServices("ChildrenLoginProvider")] IConnectionService connectionService) 
        { 
        _connectionService = connectionService;
        }



        public async Task<bool> GetUser(LoginModel loginModel)
        {
            await _connectionService.GetConnection().OpenAsync();
            using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
            {

                command.Parameters.Add(new SqlParameter("@username", loginModel.Username));
                command.Parameters.Add(new SqlParameter("@password", loginModel.Password));


                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (reader.Read() == true)
                    {
                        loginModel.uniqueId = reader.GetInt32(reader.GetOrdinal("id"));
                      
                        loginModel.Name = reader["name"].ToString();
                        loginModel.Username = reader["username"].ToString();
                        loginModel.avatar = reader["avatar"].ToString();
                        await _connectionService.GetConnection().CloseAsync();
                        return true;


                    }
                    else
                    {
                        await _connectionService.GetConnection().CloseAsync();
                        return false;
                    }

                }





            }

        }
    }
}
