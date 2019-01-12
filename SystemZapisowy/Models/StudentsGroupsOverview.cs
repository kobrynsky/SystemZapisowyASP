using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    [Table("StudentsGroupsOverview")]
    public partial class StudentsGroupsOverview
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string LastName { get; set; }

        [Key]
        [Column(Order = 2, TypeName = "numeric")]
        public decimal IndexNumber { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string Course { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(15)]
        public string Type { get; set; }

        [Key]
        [Column(Order = 5)]
        public TimeSpan StartTime { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(15)]
        public string Day { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(50)]
        public string Teacher { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(50)]
        public string FieldOfStudy { get; set; }

        [Key]
        [Column(Order = 9)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaximumSeats { get; set; }

        [Key]
        [Column(Order = 10)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OccupiedSeats { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(3)]
        public string Semester { get; set; }
    }
}
