using System.Web.Mvc;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentsService _studentsService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentsService = new StudentsService();
        }

        // GET: Students
        public ActionResult Index()
        {
            var viewModel = _studentsService.GetStudentsWithPersonalInformation();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StudentWithGroupsViewModel student)
        {
            _studentsService.SaveStudent(student);
            return RedirectToAction("Index", "Students");
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _studentsService.GetStudentWithGroupsViewModel(id);

            if (viewModel == null) return HttpNotFound();

            return View("StudentGroups", viewModel);
        }

        public ActionResult SignOutStudent(int groupId, int userId)
        {
            _studentsService.SignOutStudent(groupId, userId);
            return RedirectToAction("Index");
        }



    }
}