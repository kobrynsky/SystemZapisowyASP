using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels.User.Student
{
    public class RegisterStudentViewModel : RegisterUserViewModel
    {
        [Required]
        [Display(Name = "Index Number")]
        [Range(000001,999999,ErrorMessage="Value must be 6 digits long")]
        [DisplayFormat(DataFormatString = "{0}")]
        public decimal IndexNumber { get; set; }

        [Required]
        [Display(Name = "Year of college")]
        [Range(1,4)]
        public int YearOfCollege { get; set; }

        public int UserId { get; set; }

        [Required]
        [Display(Name = "Semester")]
        public int SemesterId { get; set; }
        public IEnumerable<Semester> Semesters { get; set; }

        [Required]
        [Display(Name = "Field of study")]
        public int FieldOfStudyId { get; set; }
        public IEnumerable<FieldsOfStudy> FieldsOfStudy{ get; set; }
    }
}