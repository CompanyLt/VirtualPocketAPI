using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class StartTaskStatusService:ITaskStatusService
    {
       IConnectionService _connectionService;

        public StartTaskStatusService([FromKeyedServices("StartTaskStatusProvider")] IConnectionService startTaskStatusProvider)
        {
            _connectionService = startTaskStatusProvider;
        }


        public async Task<bool> Execute(TaskForm taskForm)
        {
            try
            {
        using(SqlConnection connection = _connectionService.GetConnection())
                    {

                        await connection.OpenAsync();
                        using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), connection))
                        {
                            command.Parameters.Add(new SqlParameter("@id",taskForm.UniqueId));
                        command.Parameters.Add(new SqlParameter("@status", taskForm.Status));
                            await command.ExecuteNonQueryAsync();


                            return true;


                        }






                    }


            }catch (Exception ex)
            {
                return false;
            }
            






         
        }

    }
}
