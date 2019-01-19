using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;

namespace SystemZapisowy.ViewModels
{
    public class NewCourseViewModel
    {
        public IEnumerable<FieldsOfStudy> FieldsOfStudy { get; set; }
        public CourseViewModel Course { get; set; }
    }
}