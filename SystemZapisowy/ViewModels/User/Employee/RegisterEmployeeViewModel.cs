using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.ViewModels.User.Employee
{
    public class RegisterEmployeeViewModel : RegisterUserViewModel
    {
        [Required]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        public int UserId { get; set; }
    }
}