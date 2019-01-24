using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Day;
using SystemZapisowy.ViewModels.Group;

namespace SystemZapisowy.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGroupsService _groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            _unitOfWork = new UnitOfWork(new SystemZapisowyEntities());
            _groupsService = new GroupsService();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(GroupFormViewModel group)
        {
            if (group.GroupId != 0)
            {
                var groupInDb = _unitOfWork.Groups.Get(group.GroupId);
                Mapper.Map(group, groupInDb);
            }
            else
                _unitOfWork.Groups.Add(Mapper.Map<GroupFormViewModel, Group>(group));

            _unitOfWork.Complete();
            return RedirectToAction("Index", "Groups");
        }


        // GET: Groups
        public ActionResult Index()
        {
            if (Session["Type"] == "Student")
            {
                int userId = int.Parse((string)Session["UserId"]);
                var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();
                var groups = _unitOfWork.Groups.GetGroupsOfAFieldOfStudy(studentInDb.FieldOfStudyId, studentInDb.SemesterId);
                
                return View(Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups));
            }
            else
            {
                var groups = _unitOfWork.Groups.GetOrdered(g => g.Cours.FieldsOfStudy.FieldOfStudyName,
                    g => g.Cours.Semester.SemesterName);
                return View(Mapper.Map<IEnumerable<Group>, IEnumerable<GroupViewModel>>(groups));
            }
        }

        public ActionResult New()
        {
            var  courses = _unitOfWork.Courses.GetAll();
            var days = _unitOfWork.Days.GetAll();
            var viewModel = new GroupFormViewModel
            {
                Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses),
                Days = Mapper.Map<IEnumerable<Day>, IEnumerable<DayViewModel>>(days)
            };

            return View("GroupForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var groupInDb = _unitOfWork.Groups.Get(id);

            if (groupInDb == null)
                return HttpNotFound();

            var courses = _unitOfWork.Courses.GetAll();
            var days = _unitOfWork.Days.GetAll();

            var viewModel = new GroupFormViewModel()
            {
                Courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses),
                Days = Mapper.Map<IEnumerable<Day>, IEnumerable<DayViewModel>>(days)
            };

            Mapper.Map(groupInDb, viewModel);
            return View("GroupForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            var groupInDb = _unitOfWork.Groups.Get(id);
            if (groupInDb.OccupiedSeats == 0)
            {
                _unitOfWork.Groups.Remove(groupInDb);
                _unitOfWork.Complete();
            }

            return RedirectToAction("Index");
        }

        public ActionResult SignUp(int id)
        {
            int userId = int.Parse((string)Session["UserId"]);

            var studentInDb = _unitOfWork.Students.Find(s => s.UserId == userId).Single();

            // todo refactor
            if (studentInDb.StudentsGroups.Any(g => g.GroupId == id  && g.IndexNumber == studentInDb.IndexNumber))
            {
                var studentGroup =
                    _unitOfWork.StudentsGroup.Find(g => g.IndexNumber == studentInDb.IndexNumber && g.GroupId == id);
                _unitOfWork.StudentsGroup.RemoveRange(studentGroup);
                _unitOfWork.Groups.Get(id).OccupiedSeats--;
            }
            else
                _unitOfWork.StudentsGroup.SignUp(studentInDb.IndexNumber, id);

            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}