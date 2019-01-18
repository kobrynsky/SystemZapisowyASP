using System;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IAccountService
    {
        ValueTuple<string, string, string> GetUserSessionData(User user);
        bool UserExistsInDatabase(User user);
        RegisterStudentViewModel GetRegisterStudentViewModelWithBasicData();
        string SaveStudent(RegisterStudentViewModel viewModel);
    }
}
