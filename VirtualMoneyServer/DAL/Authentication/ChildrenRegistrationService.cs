using Microsoft.Data.SqlClient;
using System.Data;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenRegistrationService:IRegistrationService
    {
     private readonly   IConnectionService _connectionService;
       private readonly ICartographyService _cartographyService;
        public ChildrenRegistrationService([FromKeyedServices("ChildrenRegistrationProvider")]IConnectionService connectionService,ICartographyService cartographyService) {
        _connectionService = connectionService;
            _cartographyService = cartographyService;
        
        
        }

      public  async Task<bool> SetUser(RegistrationModel registrationModel)
       {

          
            using (SqlConnection connection = _connectionService.GetConnection())
            {
                await connection.OpenAsync();
                using( SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), connection,transaction))
                        {
                            command.Parameters.Add(new SqlParameter("@email", registrationModel.Email));
                            command.Parameters.Add(new SqlParameter("@username", registrationModel.Username));
                            int count_login = (int)command.ExecuteScalar();


                            if(count_login > 0)
                            {
                               
                                await transaction.RollbackAsync();
                                return false;
                            }

                            //Console.WriteLine($"patikra {count_login.ToString()}");
                            _connectionService.SetQueryAction();
                            
                                //  registrationModel.uniqueId = _cartographyService.GetCartography(registrationModel.Email);
                                using (SqlCommand registration = new SqlCommand(_connectionService.GetQueryAction(), connection,transaction))
                                {
                                    registration.Parameters.Add(new SqlParameter("@name", registrationModel.Name));
                                    registration.Parameters.Add(new SqlParameter("@surename", registrationModel.Surname));
                                    registration.Parameters.Add(new SqlParameter("@username", registrationModel.Username));
                                    registration.Parameters.Add(new SqlParameter("@password", registrationModel.Password));
                                    registration.Parameters.Add(new SqlParameter("@email", registrationModel.Email));
                                    int createdUserId = Convert.ToInt32(await registration.ExecuteScalarAsync());
                                    registrationModel.uniqueId = createdUserId;

                                    string addPocketQuery = "INSERT INTO Pocket(childrenId,Balance) VALUES(@id,@balance)";
                                Console.WriteLine("TOks yra pries");
                                using (SqlCommand addPocket = new SqlCommand(addPocketQuery, connection,transaction))
                                    {

                                        addPocket.Parameters.Add(new SqlParameter("@id", createdUserId));
                                        addPocket.Parameters.Add(new SqlParameter("@balance", SqlDbType.BigInt) { Value=0});
                                        await addPocket.ExecuteNonQueryAsync();

                                    }
                                }





                                await transaction.CommitAsync();
                              
                                return true;
                            
                        }


                    }
                    catch(Exception ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Klaida: {ex.Message}");
                        return false;



                    }






                }


            }





           
            


       }
    }
}
