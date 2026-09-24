using VirtualPocket.Model;

namespace VirtualPocket.DAL.ApiCenter
{
    public interface IGetApiCommandsService
    {


        Task<ApiCommands> GetApiCommandsAsync(string apiKey);
    }
}
