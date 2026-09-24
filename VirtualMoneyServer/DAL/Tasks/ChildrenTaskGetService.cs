using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Tasks
{
    public class ChildrenTaskGetService:ITaskGetService
    {

   IConnectionService _connectionService;


        //public ChildrenTaskGetService([FromKeyedServices("ChildrenTaskGetProvider")]IConnectionService connectionService)
        //{
        //    _connectionService = connectionService;
        //}

      


        public ChildrenTaskGetService([FromKeyedServices("ChildrenTaskGetProvider")] IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<IEnumerable<TaskForm>> GetTasks(int childrenId)
        {
            List<TaskForm> taskList = new List<TaskForm>();

            try
            {
                await _connectionService.GetConnection().OpenAsync();
                using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@assignId", childrenId));

                    using (SqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            TaskForm taskForm= new TaskForm
                            {
                                Title = reader.IsDBNull(reader.GetOrdinal("title")) ? null : reader.GetString(reader.GetOrdinal("title")),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                                Category = (reader.IsDBNull(reader.GetOrdinal("categoryId")) ? 0 : (TaskCategory)reader.GetInt32(reader.GetOrdinal("categoryId"))),
                                Reward = reader.IsDBNull(reader.GetOrdinal("reward")) ? 0 : reader.GetInt32(reader.GetOrdinal("reward")),
                                UniqueId = reader.IsDBNull(reader.GetOrdinal("id")) ? 0 : reader.GetInt32(reader.GetOrdinal("id")),
                                Status = reader.IsDBNull(reader.GetOrdinal("status")) ? null : reader.GetString(reader.GetOrdinal("status"))




                            };



                            taskList.Add(taskForm);
                        }


                    }


                }

            }
            catch (Exception ex)
            {

                return new List<TaskForm>();
            }



            return taskList;
        }
    }




}

