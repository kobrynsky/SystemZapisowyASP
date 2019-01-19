using System.Collections.Generic;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseFormViewModel
    {
        public IEnumerable<FieldsOfStudy> FieldsOfStudy { get; set; }
        public IEnumerable<Semester> Semesters{ get; set; }
        public CourseViewModel Course { get; set; }
    }
}