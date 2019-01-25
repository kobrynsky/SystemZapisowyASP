using System.Collections.Generic;
using SystemZapisowy.Models;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        IEnumerable<Group> GetStudentsGroups(int id);
        Student GetStudentByUserId(int id);
        void SignOutStudentFromGroup(int groupId, int userId);
    }
}
