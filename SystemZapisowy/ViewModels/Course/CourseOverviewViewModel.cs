using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels.Course
{
    public class CourseOverviewViewModel
    {
        public IEnumerable<FieldsOfStudy> FieldsOfStudy { get; set; }
        public IEnumerable<Semester> Semesters { get; set; }
        public CourseViewModel Course { get; set; }
    }
}