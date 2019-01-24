using System.Collections.Generic;
using SystemZapisowy.ViewModels.FieldOfStudy;
using SystemZapisowy.ViewModels.Semester;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseFormViewModel
    {
        public IEnumerable<FieldsOfStudyViewModel> FieldsOfStudy { get; set; }
        public IEnumerable<SemesterViewModel> Semesters{ get; set; }
        public CourseViewModel Course;
    }
}