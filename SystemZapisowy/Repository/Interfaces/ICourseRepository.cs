using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface ICourseRepository : IRepository<Courses>
    {
        IEnumerable<Courses> GetCoursesWithGroups(int pageIndex, int pageSize);
    }
}