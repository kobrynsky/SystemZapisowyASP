using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;

namespace SystemZapisowy.Controllers
{
    public class CoursesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICoursesService _coursesService;

        public CoursesController(ICoursesService coursesService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _coursesService = new CoursesService();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CourseViewModel course)
        {
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
            if (Session["Type"] == "Student")
            {
                int userId = int.Parse((string)Session["UserId"]);
                var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();
                var coursesOfAFieldOfStudy = _unitOfWork.Courses.GetCoursesOfAFieldOfStudy(studentInDb.FieldOfStudyId,
                    studentInDb.SemesterId);
                var model = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseOverviewViewModel>>(coursesOfAFieldOfStudy);
                return View(model);
            }
            else
            {
                var coursesOrdered = _unitOfWork.Courses.GetOrdered(c => c.Semester.SemesterName, c => c.FieldsOfStudy.FieldOfStudyName);
                var model = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseOverviewViewModel>>(coursesOrdered);
                
                return View(model);
            }
        }

        public ActionResult New()
        {
            var viewModel = new CourseFormViewModel
            {
                FieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll(),
                Semesters = _unitOfWork.Semesters.GetAll()
            };
            return View("CourseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var courseInDb = _unitOfWork.Courses.Get(id);

            if (courseInDb == null)
                return HttpNotFound();

            var viewModel = new CourseFormViewModel
            {
                Course = Mapper.Map<Course, CourseViewModel>(courseInDb),
                Semesters = _unitOfWork.Semesters.GetAll(),
                FieldsOfStudy = _unitOfWork.FieldsOfStudy.GetAll()
            };


            return View("CourseForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            // Czy jest sens drugi raz sprawdzać czy ten kurs ma jakieś grupy? Widok by nas nie puścił.
            var courseInDb = _unitOfWork.Courses.Get(id);
            if (courseInDb.Groups.Count == 0)
            {
                _unitOfWork.Courses.Remove(courseInDb);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
        }
    }
}