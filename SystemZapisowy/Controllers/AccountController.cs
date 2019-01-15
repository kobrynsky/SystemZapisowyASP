using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;

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
                if (data == null)
                {
                    ModelState.AddModelError("", "Email or password is wrong.");
                }
                else
                {
                    Session["UserID"] = data.UserId.ToString();
                    Session["UserEmail"] = data.Email;
                    Session["Type"] = data.Type;
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
    }
}