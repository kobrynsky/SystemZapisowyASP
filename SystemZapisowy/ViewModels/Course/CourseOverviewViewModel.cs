using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseOverviewViewModel
    {
        public ICollection<Models.Group> Groups { get; set; }
        public FieldsOfStudy FieldsOfStudy{ get; set; }
        public Semester Semester { get; set; }

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