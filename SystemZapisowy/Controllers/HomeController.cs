using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        // for DI(?)
        //public HomeController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        public HomeController()
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
        }

        public ActionResult Index()
        {
            var courses = _unitOfWork.Courses.GetAll();

            return View(courses);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
    }
}