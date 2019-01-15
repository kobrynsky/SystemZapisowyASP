//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SystemZapisowy
{
    using System;
    using System.Collections.Generic;
    
    public partial class Group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Group()
        {
            this.StudentEnrollmentLogs = new HashSet<StudentEnrollmentLog>();
            this.StudentsGroups = new HashSet<StudentsGroup>();
        }
    
        public int GroupId { get; set; }
        public int CourseId { get; set; }
        public string Type { get; set; }
        public System.TimeSpan StartTime { get; set; }
        public int DayId { get; set; }
        public string Teacher { get; set; }
        public int MaximumSeats { get; set; }
        public int OccupiedSeats { get; set; }
    
        public virtual Course Cours { get; set; }
        public virtual Day Day { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollmentLog> StudentEnrollmentLogs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsGroup> StudentsGroups { get; set; }
    }
}
