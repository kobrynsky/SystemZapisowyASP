using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountController()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }


        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                var userInDatabase =
                    _unitOfWork.Users.Find(x => x.Email.Equals(user.Email) && x.Password.Equals(user.Password)).FirstOrDefault();

                    if (userInDatabase != null)
                    {
                      //  var isAdmin = _unitOfWork.Admins.Find(x => x.UserId == userInDatabase.UserId).FirstOrDefault();


                        Session["UserID"] = userInDatabase.UserId.ToString();
                        Session["UserEmail"] = userInDatabase.Email;
                                

                    //    Session["Type"] = userInDatabase.
                    return RedirectToAction("Index", "Home");
                }
                    else
                    {
                        ModelState.AddModelError("", "Email or passowrd is wrong.");
                    }
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
    }
}