namespace VirtualPocket.DAL.Collaboration
{
    public interface ICollaborateSetService
    {

        Task<bool> SetCollaborate(int parentId, int childrenId);
    }
}
