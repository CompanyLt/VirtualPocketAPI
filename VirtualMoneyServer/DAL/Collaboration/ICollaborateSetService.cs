using VirtualPocket.Model;

namespace VirtualPocket.DAL.Collaboration
{
    public interface ICollaborateSetService
    {

        Task<User> SetCollaborate(int parentId, int childrenId);
    }
}
