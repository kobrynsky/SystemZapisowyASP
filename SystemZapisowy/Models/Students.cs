using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            StudentEnrollmentLog = new HashSet<StudentEnrollmentLog>();
            StudentsGroups = new HashSet<StudentsGroups>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal IndexNumber { get; set; }

        public int FieldOfStudyId { get; set; }

        public int YearOfCollege { get; set; }

        public int SemesterId { get; set; }

        public int UserId { get; set; }

        public virtual FieldsOfStudy FieldsOfStudy { get; set; }

        public virtual Semesters Semesters { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentEnrollmentLog> StudentEnrollmentLog { get; set; }

        public virtual Users Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentsGroups> StudentsGroups { get; set; }
    }
}
