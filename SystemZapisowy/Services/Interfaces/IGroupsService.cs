using System.Collections.Generic;
using SystemZapisowy.ViewModels.Group;

namespace SystemZapisowy.Services.Interfaces
{
    public interface IGroupsService
    {
        void Save(GroupFormViewModel group);
        IEnumerable<GroupViewModel> GetGroups();
        GroupFormViewModel GetNewGroupFormViewModel();
        GroupFormViewModel GetEditGroupFormViewModel(int id);
        void Delete(int id);
        void SignUp(int id);
    }
}