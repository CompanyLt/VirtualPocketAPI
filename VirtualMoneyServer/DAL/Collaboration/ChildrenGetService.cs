using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Collaboration
{
    public class ChildrenGetService:ICollaborateGetService
    {

        IConnectionService _connectionService;


        public ChildrenGetService([FromKeyedServices("ChildrenGetProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<IEnumerable<User>> GetCollaborate(int parentId)
        {
            List<User> childrenList = new List<User>();

            try
            {
                await _connectionService.GetConnection().OpenAsync();
                using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@id", parentId));                  
                   
                    using(SqlDataReader reader =await command.ExecuteReaderAsync()) 
                    {
                        while(await reader.ReadAsync())
                        {
                            User user = new User
                            {
                               Name = reader.IsDBNull(reader.GetOrdinal("name"))? null: reader.GetString(reader.GetOrdinal("name")),
                               UniqueId = reader.IsDBNull(reader.GetOrdinal("id"))? 0:reader.GetInt32(reader.GetOrdinal("id"))



                            };



                            childrenList.Add(user);
                        }

                    
                    }


                }
               
            }
            catch (Exception ex)
            {

               return new List<User>();
            }
         


          return childrenList;
        }
    }
}
