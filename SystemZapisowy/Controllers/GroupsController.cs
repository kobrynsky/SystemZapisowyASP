using System.Web.Mvc;
using SystemZapisowy.Services;
using SystemZapisowy.Services.Interfaces;
using SystemZapisowy.ViewModels.Group;

namespace SystemZapisowy.Controllers
{
    public class GroupsController : Controller
    {
        private readonly IGroupsService _groupsService;

        public GroupsController(IGroupsService groupsService)
        {
            _groupsService = new GroupsService();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Save(GroupFormViewModel group)
        {
            _groupsService.Save(group);
            return RedirectToAction("Index", "Groups");
        }


        // GET: Groups
        public ActionResult Index()
        {
            var viewModel = _groupsService.GetGroups();
            return View(viewModel);
        }

        public ActionResult New()
        {
            var viewModel = _groupsService.GetNewGroupFormViewModel();
            return View("GroupForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = _groupsService.GetEditGroupFormViewModel(id);

            if (viewModel == null) return HttpNotFound();

            return View("GroupForm", viewModel);
        }

        public ActionResult Delete(int id)
        {
            _groupsService.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult SignUp(int id)
        {
            _groupsService.SignUp(id);
            return RedirectToAction("Index");
        }
    }
}