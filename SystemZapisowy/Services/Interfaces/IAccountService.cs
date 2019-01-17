using System;
using SystemZapisowy.Models;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IAccountService
    {
        ValueTuple<string, string, string> GetUserSessionData(User user);
        bool UserExistsInDatabase(User user);
    }
}
