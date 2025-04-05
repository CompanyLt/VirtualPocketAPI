namespace VirtualPocket.DAL.Collaboration
{
    public interface ICollaborateGetService
    {


        Task<IEnumerable<int>> GetCollaborate(int parentId);
    }
}
