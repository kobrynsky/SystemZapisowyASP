using System.Collections.Generic;
using SystemZapisowy.Models;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesOfAFieldOfStudy(int fieldOfStudyId);
        IEnumerable<Course> GetCoursesOfAFieldOfStudy(int fieldOfStudyId, int semesterId);
    }
}