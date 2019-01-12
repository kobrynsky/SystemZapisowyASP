using System.ComponentModel.DataAnnotations.Schema;

namespace SystemZapisowy.Models
{
    public partial class StudentsGroups
    {
        public int StudentsGroupsId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal IndexNumber { get; set; }

        public int GroupId { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Students Students { get; set; }
    }
}
