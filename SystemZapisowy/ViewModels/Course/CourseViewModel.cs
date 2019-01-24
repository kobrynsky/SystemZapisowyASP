using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseViewModel
    {
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
