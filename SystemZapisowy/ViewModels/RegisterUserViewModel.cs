using System;

namespace SystemZapisowy.ViewModels
{
    public class RegisterUserViewModel
    {
        public int PESEL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}