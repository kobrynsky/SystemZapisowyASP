using System.Collections.Generic;
using SystemZapisowy.Models;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesWithGroups(int pageIndex, int pageSize);
    }
}