namespace SystemZapisowy.ViewModels
{
    public class RegisterStudentViewModel: RegisterUserViewModel
    {
        public int IndexNumber { get; set; }
        public int FieldOfStudyId { get; set; }
        public int YearOfCollege { get; set; }
        public int SemesterId { get; set; }
        public int UserId { get; set; }
    }
}