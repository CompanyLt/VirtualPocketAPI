namespace VirtualPocket.DAL.Collaboration
{
    public class ChildrenSetService:ICollaborateSetService
    {

        IConnectionService _connectionService;


        public ChildrenSetService([FromKeyedServices("ChildrenSetProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<bool> SetCollaborate(int parentId, int childrenId)
        {








            return true;
        }
    }
}
