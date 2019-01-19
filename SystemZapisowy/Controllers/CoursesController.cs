using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;

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
        public ActionResult Save(CourseViewModel course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseFormViewModel
                {
                    Course = course,
                    FieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll(),
                    Semesters = _unitOfWork.Semesters.GetAll()
                };
                return View("CourseForm", viewModel);
            }

            if (course.CourseId != 0)
            {
                var courseInDb = _unitOfWork.Courses.Get(course.CourseId);
                Mapper.Map(course, courseInDb);
            }
            else
                _unitOfWork.Courses.Add(Mapper.Map<CourseViewModel, Course>(course));
            

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Courses");
        }


        // GET: Course
        public ActionResult Index()
        {
            IEnumerable<Course> model = _unitOfWork.Courses.GetAll();
            return View(model);
        }

        public ActionResult New()
        {
            var fieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll();
            var semesters = _unitOfWork.Semesters.GetAll();
            var viewModel = new CourseFormViewModel
            {
                FieldsOfStudy = fieldsOfStudy,
                Semesters = semesters

            };
            return View("CourseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var course = _unitOfWork.Courses.Get(id);
            var tmp = Mapper.Map<Course, CourseViewModel>(course);

            if (course == null)
                return HttpNotFound();

            var viewModel = new CourseFormViewModel
            {
                Course = tmp,
                Semesters = _unitOfWork.Semesters.GetAll(),
                FieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll()
            };


            return View("CourseForm", viewModel);
        }
    }
}