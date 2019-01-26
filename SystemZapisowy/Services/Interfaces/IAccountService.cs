using System;
using SystemZapisowy.Models;
using SystemZapisowy.ViewModels.User.Administrator;
using SystemZapisowy.ViewModels.User.Employee;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IAccountService
    {
        ValueTuple<string, string, string> GetUserSessionData(User user);
        bool UserExistsInDatabase(User user);
        RegisterStudentViewModel GetRegisterStudentViewModelWithBasicData();
        void SaveStudent(RegisterStudentViewModel viewModel);
        void SaveEmployee(RegisterEmployeeViewModel viewModel);
        void SaveAdministrator(RegisterAdministratorViewModel viewModel);
    }
}
