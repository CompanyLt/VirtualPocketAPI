using Microsoft.Data.SqlClient;
using VirtualPocket.Model;

namespace VirtualPocket.DAL.Collaboration
{
    public class CollaborateRemoveService:ICollaborateRemoveService
    {

        IConnectionService _connectionService;


        public CollaborateRemoveService([FromKeyedServices("CollaborateRemoveProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<bool> RemoveCollaborate(int parentId, int childrenId)
        {
            try
            {
                await _connectionService.GetConnection().OpenAsync();
                using (SqlCommand command = new SqlCommand(_connectionService.GetQueryAction(), _connectionService.GetConnection()))
                {
                    command.Parameters.Add(new SqlParameter("@parentId", parentId));
                    command.Parameters.Add(new SqlParameter("@childrenId", childrenId));
                    await command.ExecuteNonQueryAsync();


                }
                return true;
            }catch (Exception ex)
            {

                return false;
            }
           











          
        }
    }
}
