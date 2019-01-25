using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;
using SystemZapisowy.ViewModels.User.Student;
using AutoMapper;

namespace SystemZapisowy.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _studentsService= new StudentsService();
        }

        // GET: Students
        public ActionResult Index()
        {
            var viewModel = _studentsService.GetStudentsWithPersonalInformation();
            return View(viewModel);
        }



    }
}