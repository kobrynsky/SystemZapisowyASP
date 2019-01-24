using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Group;
using SystemZapisowy.ViewModels.Semester;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseOverviewViewModel
    {
        public ICollection<GroupViewModel> Groups { get; set; }
        public FieldsOfStudyViewModel FieldsOfStudy { get; set; }
        public SemesterViewModel Semester { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string CourseName { get; set; }

        [Display(Name = "Semester")]
        public int SemesterId { get; set; }

        [Display(Name = "Field of study")]
        public int FieldOfStudyId { get; set; }
    }
}