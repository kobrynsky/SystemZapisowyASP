using System;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAdministratorRepository Administrators { get; }
        ICourseRepository Courses { get; }
        IDayRepository Days { get; }
        IEmployeeRepository Employees { get; }
        IFieldsOfStudyRepository FieldsOfStudy { get; }
        IGroupRepository Groups { get; }
        ISemesterRepository Semesters { get; }
        IStudentEnrollmentLogRepository Logs { get; }
        IStudentRepository Students { get; }
        IStudentsGroupRepository StudentsGroup { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}