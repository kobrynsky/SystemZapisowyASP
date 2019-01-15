using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        IEnumerable<Course> GetCoursesWithGroups(int pageIndex, int pageSize);
    }
}