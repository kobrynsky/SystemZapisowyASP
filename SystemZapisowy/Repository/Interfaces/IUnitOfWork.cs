using System;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IUserRepository Users { get; }
        IAdministratorRepository Administrators { get; }
        IEmployeeRepository Employees { get; }
        IStudentRepository Students { get; }
        int Complete();
    }
}