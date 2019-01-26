using System.Collections.Generic;
using SystemZapisowy.ViewModels.Course;

namespace SystemZapisowy.Services.Interfaces
{
    public interface ICoursesService
    {
        IEnumerable<CourseOverviewViewModel> GetCoursesOverviewViewModel();
        CourseFormViewModel GetNewCourseFormViewModel();
        CourseFormViewModel GetEditCourseFormViewModel(int id);
        void DeleteCourse(int id);
        void SaveCourse(CourseViewModel course);
    }
}