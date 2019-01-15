using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SystemZapisowyEntities _context;

        public UnitOfWork(SystemZapisowyEntities context)
        {
            _context = context;
            Courses = new CourseRepository(_context);
            Users = new UserRepository(_context);
            Administrators = new AdministratorRepository(_context);
            Employees = new EmployeeRepository(_context);
            Students = new StudentRepository(_context);
        }

        public ICourseRepository Courses { get; private set; }
        public IUserRepository Users { get; }
        public IAdministratorRepository Administrators { get; }
        public IEmployeeRepository Employees { get; }
        public IStudentRepository Students { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}