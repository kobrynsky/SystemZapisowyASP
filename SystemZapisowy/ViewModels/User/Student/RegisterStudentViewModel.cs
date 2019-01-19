using System.Collections.Generic;
using System.Web.Mvc;

namespace SystemZapisowy.ViewModels.User.Student
{
    public class RegisterStudentViewModel : RegisterUserViewModel
    {
        public RegisterStudentViewModel()
        {
            Semesters = new List<SelectListItem>();
            FieldsOfStudy = new List<SelectListItem>();
        }

        public int IndexNumber { get; set; }
        public int YearOfCollege { get; set; }
        public int UserId { get; set; }


        public int SelectedSemesterId { get; set; }
        public IEnumerable<SelectListItem> Semesters { get; set; }

        public int SelectedFieldOfStudyId { get; set; }
        public IEnumerable<SelectListItem> FieldsOfStudy{ get; set; }
    }
}