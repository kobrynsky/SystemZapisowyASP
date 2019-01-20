using System;
using System.ComponentModel.DataAnnotations;

namespace SystemZapisowy.ViewModels.User
{
    public class RegisterUserViewModel
    {
        [Display(Name = "PESEL")]
        [Required, RegularExpression(@"^\d{11}$", ErrorMessage = "Value must be 11 digits long")]
        public decimal PESEL { get; set; }

        [Required]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Birthdate")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(10)]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}