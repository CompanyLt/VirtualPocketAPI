using VirtualPocket.Model;

namespace VirtualPocket.DAL.Collaboration
{
    public interface ICollaborateGetService
    {


        Task<IEnumerable<User>> GetCollaborate(int parentId);
    }
}
