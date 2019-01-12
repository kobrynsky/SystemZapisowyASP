using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.Models
{
    public partial class Days
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Days()
        {
            Groups = new HashSet<Groups>();
        }

        [Key]
        public int DayId { get; set; }

        [Required]
        [StringLength(15)]
        public string Day { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Groups> Groups { get; set; }
    }
}
