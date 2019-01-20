using System.Linq;
using AutoMapper;
using System.Web.Mvc;
using SystemZapisowy.Models;
using SystemZapisowy.Repository;
using SystemZapisowy.Repository.Interfaces;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
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
            var model = _unitOfWork.Groups.GetOrdered(g => g.Cours.FieldsOfStudy.Name,
                g => g.Cours.Semester.Name);
            return View(model);
        }

        public ActionResult New()
        {
            var viewModel = new GroupFormViewModel
            {
                Courses = _unitOfWork.Courses.GetAll(),
                Days = _unitOfWork.Days.GetAll()
            };

            return View("GroupForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var groupInDb = _unitOfWork.Groups.Get(id);

            if (groupInDb == null)
                return HttpNotFound();

            var viewModel = new GroupFormViewModel()
            {
                Days = _unitOfWork.Days.GetAll(),
                Courses = _unitOfWork.Courses.GetAll()
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
            
            //if(studentInDb.StudentsGroups.Contains())

            _unitOfWork.StudentsGroup.SignUp(studentInDb.IndexNumber, id);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}