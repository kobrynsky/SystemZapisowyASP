using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.ViewModels.Course;
using SystemZapisowy.ViewModels.Group;

namespace SystemZapisowy.ViewModels.User.Student
{
    public class StudentWithGroupsViewModel 
    {
        public StudentViewModel Student { get; set; }
        public IEnumerable<GroupViewModel> Groups { get; set; }
        //public IEnumerable<CourseViewModel> Courses { get; set; }
    }
}