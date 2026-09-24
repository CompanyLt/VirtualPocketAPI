using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskSetService:ITaskSetService
    {
        IConnectionService _connectionService;

        public ChildrenTaskSetService([FromKeyedServices("ChildrenTaskSetProvider")] IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }

        public async Task<bool> SetTask(TaskForm taskForm)
        {
         
            await _connectionService.GetConnection().OpenAsync();
            using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
            {
                command.Parameters.Add(new SqlParameter("@title",taskForm.Title));
                command.Parameters.Add(new SqlParameter("@description", taskForm.Description));
                command.Parameters.Add(new SqlParameter("@status", taskForm.Status));
                command.Parameters.Add(new SqlParameter("@reward", taskForm.Reward));
                command.Parameters.Add(new SqlParameter("@assignId", taskForm.UniqueId));
                int createdTaskId = Convert.ToInt32(await command.ExecuteScalarAsync());


               
                //Pakeiciame query
                _connectionService.SetQueryAction();
              
                    //  registrationModel.uniqueId = _cartographyService.GetCartography(registrationModel.Email);
                    using (SqlCommand registration = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                    {
                        registration.Parameters.Add(new SqlParameter("@taskId", createdTaskId));
                        registration.Parameters.Add(new SqlParameter("@categoryId", (int)taskForm.Category));
                        

                     await registration.ExecuteNonQueryAsync();

                   
                    }
                    await _connectionService.GetConnection().CloseAsync();
               



            }







            return true;
        }
    }
}
