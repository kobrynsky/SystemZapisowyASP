using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;

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
            _coursesService.SaveCourse(course);
            return RedirectToAction("Index", "Courses");
        }


        // GET: Course
        public ActionResult Index()
        {
            var viewModel = _coursesService.GetCoursesOverviewViewModel();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = _coursesService.GetNewCourseFormViewModel();
            return View("CourseForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _coursesService.GetEditCourseFormViewModel(id);

            if (viewModel == null) return HttpNotFound();

            return View("CourseForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            _coursesService.DeleteCourse(id);
            return RedirectToAction("Index");
        }
    }
}