using System.Collections.Generic;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IStudentsService
    {
        IEnumerable<StudentViewModel> GetStudentsWithPersonalInformation();
    }
}