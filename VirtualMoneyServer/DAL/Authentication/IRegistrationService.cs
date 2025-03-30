using VirtualPocket.Model;

namespace VirtualPocket.DAL.Authentication
{
    public interface IRegistrationService
    {





        Task<bool> SetUser(RegistrationModel registrationModel);

    }
}
