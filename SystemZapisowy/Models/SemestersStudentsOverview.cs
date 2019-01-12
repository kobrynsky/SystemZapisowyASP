using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    [Table("SemestersStudentsOverview")]
    public partial class SemestersStudentsOverview
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(3)]
        public string Semester { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal IndexNumber { get; set; }

        [Key]
        [Column(Order = 4)]
        public DateTime BirthDate { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(10)]
        public string Gender { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string Email { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal PESEL { get; set; }
    }
}
