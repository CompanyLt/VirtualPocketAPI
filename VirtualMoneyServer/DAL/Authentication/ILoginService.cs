using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public interface ILoginService
    {





        Task<bool> GetUser(LoginModel loginModel);
    }
}
