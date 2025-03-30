using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public class ChildrenRegistrationService:IRegistrationService
    {
     private readonly   IConnectionService _connectionService;

        public ChildrenRegistrationService([FromKeyedServices("ChildrenConnectionService")]IConnectionService connectionService) {
        _connectionService = connectionService;
        
        
        }

      public  async Task<bool> SetUser(RegistrationModel registrationModel)
        {

            await _connectionService.GetConnection().OpenAsync();
            using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
            {

                //                command.Parameters.Add(new SqlParameter("@id", queryService.idGet()));
                //                command.Parameters.Add(new SqlParameter("@category", taskForm.category));
                //                command.Parameters.Add(new SqlParameter("@status", 1));

                //                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                //                {
                //#nullable disable

                //                    while (await reader.ReadAsync())
                //                    {

                //                        // Console.WriteLine("sdsd");
                //                        IncidentForm Gedimo_forma = new IncidentForm(
                //                            reader["List"].ToString(),
                //                            reader["Description"].ToString(),
                //                            Convert.ToInt32(reader["Record_Id"]),
                //                            reader["Solution"].ToString()

                //                            );

                //                        taskForm.incidentCollection.Add(Gedimo_forma);
                //                        //  Console.WriteLine(reader["List"].ToString());




                //                    }
                //#nullable enable


                //                }


                //            }
                //            await queryService.sqlConnGet().CloseAsync();

                return true;
            }

        }
    }
}
