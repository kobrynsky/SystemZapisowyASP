using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels;

namespace SystemZapisowy.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService accountService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _courseService = new CourseService();
        }

        public ActionResult Create()
        {
            return View();
        }


        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var viewModel = new NewCourseViewModel
            {
                FieldsOfStudy = fieldsOfStudy
            };
            return View(viewModel);
        }
    }
}