using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels;
using SystemZapisowy.ViewModels.User.Administrator;
using SystemZapisowy.ViewModels.User.Employee;
using SystemZapisowy.ViewModels.User.Student;

namespace SystemZapisowy.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _accountService = new AccountService();
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid && _accountService.UserExistsInDatabase(user))
            {
                var data = _accountService.GetUserSessionData(user);
                if (data.Item1.Equals(""))
                {
                    ModelState.AddModelError("", "Email or password is wrong.");
                }
                else
                {
                    Session["UserID"] = data.Item1;
                    Session["UserEmail"] = data.Item2;
                    Session["Type"] = data.Item3;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                ModelState.AddModelError("", "Email or password is wrong.");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterStudent()
        {
            var viewModel = _accountService.GetRegisterStudentViewModelWithBasicData();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterStudent(RegisterStudentViewModel viewModel)
        {
            _accountService.SaveStudent(viewModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterEmployee()
        {
            var viewModel = new RegisterEmployeeViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterEmployee(RegisterEmployeeViewModel viewModel)
        {
            _accountService.SaveEmployee(viewModel);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult RegisterAdministrator()
        {
            var viewModel = new RegisterAdministratorViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterAdministrator(RegisterAdministratorViewModel viewModel)
        {
            _accountService.SaveAdministrator(viewModel);
            return RedirectToAction("Index", "Home");
        }
    }

}