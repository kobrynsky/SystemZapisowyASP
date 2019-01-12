using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    [Table("StudentEnrollmentLog")]
    public partial class StudentEnrollmentLog
    {
        public int Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IndexNumber { get; set; }

        public int GroupId { get; set; }

        [Required]
        [StringLength(50)]
        public string MessageText { get; set; }

        public DateTime DateOfOperation { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Students Students { get; set; }
    }
}
