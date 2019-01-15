using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(SystemZapisowyEntities context) : base(context)
        {
        }

        public IEnumerable<Course> GetCoursesWithGroups(int pageIndex, int pageSize = 10)
        {
            return SystemZapisowyEntities.Courses
                .Include(c => c.Groups)
                .OrderBy(c => c.Name)
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