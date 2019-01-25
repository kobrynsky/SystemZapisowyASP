using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;

namespace SystemZapisowy.ViewModels.User.Student
{
    public class StudentViewModel
    {
        public int UserId { get; set; }
        public decimal PESEL { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public System.DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public decimal IndexNumber { get; set; }
        public int FieldOfStudyId { get; set; }
        public int YearOfCollege { get; set; }
        public int SemesterId { get; set; }

        public FieldsOfStudyViewModel FieldsOfStudy { get; set; }
        public SemesterViewModel Semester { get; set; }
    }
}