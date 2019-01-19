using SystemZapisowy.ViewModels.User.Employee;

namespace SystemZapisowy.ViewModels.User.Administrator
{
    public class RegisterAdministratorViewModel: RegisterEmployeeViewModel
    {
        public int EmployeeId { get; set; }
    }
}