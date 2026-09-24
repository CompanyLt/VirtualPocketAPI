using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Collaboration
{
    public class CollaborateSetService : ICollaborateSetService
    {

        IConnectionService _connectionService;


        public CollaborateSetService([FromKeyedServices("CollaborateSetProvider")] IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<User> SetCollaborate(int parentId, int childrenId)
        {
            try
            {
              
                
                //  int checkCount;
                using (SqlConnection connection = _connectionService.GetConnection())
                {
                    
                    await connection.OpenAsync();
                    object checkResult;
                    User? user = null;
                    using (SqlCommand cmd = new SqlCommand(_connectionService.GetQueryAction(), connection))
                    {
                        cmd.Parameters.Add(new SqlParameter("@id", childrenId));

                        
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                           
                            if (await reader.ReadAsync())
                            {
                               
                                user = new User
                                {
                                    UniqueId = reader.GetInt32(reader.GetOrdinal("id")),
                                    Name = reader["name"].ToString(),
                                    Username = reader["username"].ToString(),
                                    isParent = false
                                };                           

                            }
                            }
                            
                     //   checkResult = await cmd.ExecuteScalarAsync();                    
                        _connectionService.SetQueryAction();

                      if (user != null)
                        {
                         using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), connection))
                                                    {

                                                        command.Parameters.Add(new SqlParameter("@parentId", parentId));
                                                        command.Parameters.Add(new SqlParameter("@childrenId", childrenId));
                                                        await command.ExecuteNonQueryAsync();
                                                    }
                      
                        }

                        return user;
                       

                    }
                }                      
            }
            catch (Exception ex)
            {

                return new User();
            }
         
        }
    }
}
