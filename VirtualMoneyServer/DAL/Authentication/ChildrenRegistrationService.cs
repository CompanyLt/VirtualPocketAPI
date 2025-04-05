using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenRegistrationService:IRegistrationService
    {
     private readonly   IConnectionService _connectionService;
       private readonly ICartographyService _cartographyService;
        public ChildrenRegistrationService([FromKeyedServices("ChildrenConnectionService")]IConnectionService connectionService,ICartographyService cartographyService) {
        _connectionService = connectionService;
            _cartographyService = cartographyService;
        
        
        }

      public  async Task<bool> SetUser(RegistrationModel registrationModel)
        {

            await _connectionService.GetConnection().OpenAsync();
            using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
            {
                command.Parameters.Add(new SqlParameter("@mail", registrationModel.Email));
                int count_login = (int)command.ExecuteScalar();


                //Console.WriteLine($"patikra {count_login.ToString()}");
                _connectionService.SetQueryAction();
                if (count_login == 0)
                {
                  //  registrationModel.uniqueId = _cartographyService.GetCartography(registrationModel.Email);
                    using (SqlCommand registration = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                    {
                        registration.Parameters.Add(new SqlParameter("@name", registrationModel.Name));
                        registration.Parameters.Add(new SqlParameter("@password", registrationModel.Password));
                        registration.Parameters.Add(new SqlParameter("@mail", registrationModel.Email));                     
                        registration.Parameters.Add(new SqlParameter("@phoneNumber", "0"));
                        await registration.ExecuteNonQueryAsync();
                    }
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
