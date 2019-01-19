using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;

namespace SystemZapisowy.Services
{
    public class CoursesService : ICoursesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursesService()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }
    }
}