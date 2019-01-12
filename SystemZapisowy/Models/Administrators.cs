using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.Models
{
    public partial class Administrators
    {
        [Key]
        public int AdministratorId { get; set; }

        public int EmployeeId { get; set; }

        public virtual Employees Employees { get; set; }
    }
}
