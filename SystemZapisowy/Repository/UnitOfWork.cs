using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        }

        public ICourseRepository Courses { get; private set; }

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