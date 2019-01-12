using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    [Table("FieldsOfStudy")]
    public partial class FieldsOfStudy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FieldsOfStudy()
        {
            Courses = new HashSet<Courses>();
            Students = new HashSet<Students>();
        }

        [Key]
        public int FieldOfStudyId { get; set; }

        [Required]
        [StringLength(50)]
        public string FieldOfStudy { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Courses> Courses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
    }
}
