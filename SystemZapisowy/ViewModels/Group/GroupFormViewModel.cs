using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Day;

namespace SystemZapisowy.ViewModels.Group
{
    public class GroupFormViewModel
    {
        public IEnumerable<DayViewModel> Days { get; set; }
        public IEnumerable<CourseViewModel> Courses { get; set; }

        [Display(Name = "Group Code")]
        public int GroupId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Start time")]
        public System.TimeSpan StartTime { get; set; }

        [Display(Name = "Day")]
        public int DayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Teacher { get; set; }

        public int MaximumSeats { get; set; }
    }
}