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

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }

        public IEnumerable<Course> GetCoursesOfAFieldOfStudy(int fieldOfStudyId)
        {
            return Context.Set<Course>().Where(c => c.FieldOfStudyId == fieldOfStudyId).OrderBy(c => c.SemesterId).ThenBy(c => c.CourseName).ToList();
        }

        public IEnumerable<Course> GetCoursesOfAFieldOfStudy(int fieldOfStudyId, int semesterId)
        {
            return Context.Set<Course>().Where(c => c.FieldOfStudyId == fieldOfStudyId && c.SemesterId == semesterId).OrderBy(c => c.CourseName).ToList();
        }
    }
}