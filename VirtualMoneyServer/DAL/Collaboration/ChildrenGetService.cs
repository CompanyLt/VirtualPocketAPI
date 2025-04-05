namespace VirtualPocket.DAL.Collaboration
{
    public class ChildrenGetService:ICollaborateGetService
    {

        IConnectionService _connectionService;


        public ChildrenGetService([FromKeyedServices("ChildrenGetProvider")]IConnectionService connectionService)
        {
            _connectionService = connectionService;
        }
        public async Task<IEnumerable<int>> GetCollaborate(int parentId)
        {





            return new List<int>();
        }
    }
}
