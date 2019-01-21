using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels.Group
{
    public class GroupFormViewModel
    {
        public IEnumerable<Day> Days { get; set; }
        public IEnumerable<Models.Course> Courses { get; set; }

        [Display(Name = "Group Code")]
        public int GroupId { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Start time")]
        //[DisplayFormat(DataFormatString = "{0:hh\\:mm")]
        public System.TimeSpan StartTime { get; set; }

        [Display(Name = "Day")]
        public int DayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Teacher { get; set; }

        public int MaximumSeats { get; set; }

        //public int OccupiedSeats { get; set; }
        //public virtual Models.Course Cours { get; set; }
        //public virtual Day Day { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentEnrollmentLog> StudentEnrollmentLogs { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentsGroup> StudentsGroups { get; set; }
    }
}