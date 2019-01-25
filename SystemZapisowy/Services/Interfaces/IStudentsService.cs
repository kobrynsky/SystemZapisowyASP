using System.Collections.Generic;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IStudentsService
    {
        IEnumerable<StudentViewModel> GetStudentsWithPersonalInformation();
        void SaveStudent(StudentWithGroupsViewModel student);
        void SignOutStudent(int groupId, int userId);
        StudentWithGroupsViewModel GetStudentWithGroupsViewModel(int id);
    }
}