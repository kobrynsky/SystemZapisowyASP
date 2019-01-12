using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            Administrators = new HashSet<Administrators>();
        }

        [Key]
        public int EmployeeId { get; set; }

        [Column(TypeName = "money")]
        public decimal Salary { get; set; }

        public int UserId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Administrators> Administrators { get; set; }

        public virtual Users Users { get; set; }
    }
}
