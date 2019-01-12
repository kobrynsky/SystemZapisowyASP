using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.Models
{
    public partial class Courses
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Courses()
        {
            Groups = new HashSet<Groups>();
        }

        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(50)]
        public string Course { get; set; }

        public int SemesterId { get; set; }

        public int FieldOfStudyId { get; set; }

        public virtual FieldsOfStudy FieldsOfStudy { get; set; }

        public virtual Semesters Semesters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groups> Groups { get; set; }
    }
}
