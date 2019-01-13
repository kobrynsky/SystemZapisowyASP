using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class CourseRepository : Repository<Courses>, ICourseRepository
    {
        public CourseRepository(SystemZapisowyEntities context) : base(context)
        {
        }

        public IEnumerable<Courses> GetCoursesWithGroups(int pageIndex, int pageSize = 10)
        {
            return SystemZapisowyEntities.Courses
                .Include(c => c.Groups)
                .OrderBy(c => c.Course)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }


        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }
    }
}