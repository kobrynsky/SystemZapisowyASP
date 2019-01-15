using SystemZapisowy.Models;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IAccountService
    {
        UserSessionData GetUserSessionData(User user);
        bool UserExistsInDatabase(User user);
    }
}
