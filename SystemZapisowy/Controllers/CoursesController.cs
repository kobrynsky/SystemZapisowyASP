using AutoMapper;
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

        [HttpPost]
        public ActionResult Create(CourseViewModel course)
        {
            var tmpCourse = Mapper.Map<CourseViewModel, Course>(course);
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCourseViewModel
                {
                    Course = course,
                    FieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll(),
                    Semesters = _unitOfWork.Semesters.GetAll()
                };
                return View("New", viewModel);
            }
            _unitOfWork.Courses.Add(tmpCourse);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Courses");
        }


        // GET: Course
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var semesters = _unitOfWork.Semesters.GetAll();
            var viewModel = new NewCourseViewModel
            {
                FieldsOfStudy = fieldsOfStudy,
                Semesters = semesters

            };
            return View(viewModel);
        }
    }
}