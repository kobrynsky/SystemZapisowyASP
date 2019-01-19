﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;
using AutoMapper;

namespace SystemZapisowy.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupsService _courseService;

        public GroupsController(IGroupsService groupsService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _courseService = new GroupsService();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CourseViewModel course)
        {
            return RedirectToAction("Index", "Groups");
        }


        // GET: Groups
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult New()
        {

            //return View("GroupForm", viewModel);
            return View();
        }

        public ActionResult Edit(int id)
        {
            //return View("GroupForm", viewModel);
            return View();
        }
    }
}