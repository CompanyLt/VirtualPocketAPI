using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.ApiCenter
{
    public class GetApiCommandsService : IGetApiCommandsService
    {

        IConnectionService _connectionService;

        public GetApiCommandsService([FromKeyedServices("GetApiCommandsProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }


        public async Task<ApiCommands> GetApiCommandsAsync(string apiKey)
        {
           
            try
            {
                await _connectionService.GetConnection().OpenAsync();

                using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@apiKey", apiKey));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {                         
                            var commands = new ApiCommands
                            {
                                GetTasksCommand = reader.GetString(reader.GetOrdinal("getTasksCommand")),
                                SetTasksCommand = reader.GetString(reader.GetOrdinal("setTasksCommand")),
                                LoginCommand = reader.GetString(reader.GetOrdinal("loginCommand")),
                                SignUpCommand = reader.GetString(reader.GetOrdinal("signUpCommand")),
                                GetCollaborateCommand = reader.GetString(reader.GetOrdinal("getCollaborateCommand")),
                                SetCollaborateCommand = reader.GetString(reader.GetOrdinal("setCollaborateCommand")),
                                GetMarketCommand = reader.GetString(reader.GetOrdinal("getMarketCommand")),
                                SetMarketCommand = reader.GetString(reader.GetOrdinal("setMarketCommand")),
                               StartTasksCommand = reader.GetString(reader.GetOrdinal("startTasksCommand")),
                               CollectRewardCommand = reader.GetString(reader.GetOrdinal("collectRewardCommand")),
                               GetPocketCommand = reader.GetString(reader.GetOrdinal("getPocketCommand")),
                               GetTaskCategoryCommand = reader.GetString(reader.GetOrdinal("getTaskCategoryCommand"))
                            };

                          
                

                            return commands;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Galima loginti klaidą
            }

            return null; // arba new ApiCommands(), jei nenori grąžinti null
        }



    }

}
