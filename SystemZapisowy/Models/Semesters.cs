using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.Models
{
    public partial class Semesters
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semesters()
        {
            Courses = new HashSet<Courses>();
            Students = new HashSet<Students>();
        }

        [Key]
        public int SemesterId { get; set; }

        [Required]
        [StringLength(3)]
        public string Semester { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
