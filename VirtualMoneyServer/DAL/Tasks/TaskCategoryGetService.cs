using Microsoft.Data.SqlClient;
using System.Diagnostics;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class TaskCategoryGetService : ITaskCategoryService
    {

        IConnectionService _connectionService;



    public TaskCategoryGetService([FromKeyedServices("TaskCategoryGetProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
     



        public async Task<IEnumerable<TaskCategoryForm>> GetTaskCategories()
        {
            List<TaskCategoryForm> list = new List<TaskCategoryForm>();

            try
            {
                await _connectionService.GetConnection().OpenAsync();
                using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                {
                  
                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TaskCategoryForm taskCategoryForm = new TaskCategoryForm()
                            {
                                Id = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32(reader.GetOrdinal("id")),
                                Name = reader.IsDBNull(reader.GetOrdinal("name")) ? null : reader.GetString(reader.GetOrdinal("name")),
                                Image = reader.IsDBNull(reader.GetOrdinal("image")) ? null : reader.GetString(reader.GetOrdinal("image"))
                            };
                            



                          list.Add(taskCategoryForm);
                        }


                    }


                }

            }
            catch (Exception ex)
            {

                return new List<TaskCategoryForm>();
            }

            return list;
           
        }
    }
}
