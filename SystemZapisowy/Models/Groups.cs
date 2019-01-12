using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.Models
{
    public partial class Groups
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Groups()
        {
            StudentEnrollmentLog = new HashSet<StudentEnrollmentLog>();
            StudentsGroups = new HashSet<StudentsGroups>();
        }

        [Key]
        public int GroupId { get; set; }

        public int CourseId { get; set; }

        [Required]
        [StringLength(15)]
        public string Type { get; set; }

        public TimeSpan StartTime { get; set; }

        public int DayId { get; set; }

        [Required]
        [StringLength(50)]
        public string Teacher { get; set; }

        public int MaximumSeats { get; set; }

        public int OccupiedSeats { get; set; }

        public virtual Courses Courses { get; set; }

        public virtual Days Days { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollmentLog> StudentEnrollmentLog { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsGroups> StudentsGroups { get; set; }
    }
}
