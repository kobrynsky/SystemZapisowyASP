using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemZapisowy.Models;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IAccountService
    {
        UserSessionData GetUserSessionData(User user);
        bool UserExistsInDatabase(User user);
    }
}
