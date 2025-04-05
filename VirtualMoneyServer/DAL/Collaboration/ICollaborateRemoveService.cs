namespace VirtualPocket.DAL.Collaboration
{
    public interface ICollaborateRemoveService
    {

        Task<bool> RemoveCollaborate(int parentId, int childrenId);
    }
}
