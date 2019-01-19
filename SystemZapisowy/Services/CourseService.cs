using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Services.Interfaces
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }

        public bool UserExistsInDatabase(Course course)
        {
            throw new NotImplementedException();
        }
    }
}