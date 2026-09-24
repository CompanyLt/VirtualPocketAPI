

using VirtualPocket.Model;

namespace VirtualPocket.DAL.PocketPlace
{
    public interface IGetPocketService
    {

        Task<Pocket> getPocketAsync(int uniqueId);
       
    }
}
