using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICourseRepository Courses { get; }
        IUserRepository Users { get; }
        int Complete();
    }
}