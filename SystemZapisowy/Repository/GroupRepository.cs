using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class GroupRepository: Repository<Group>, IGroupRepository
    {

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }

        public GroupRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Group> GetGroupsOfACourse(int courseId)
        {
            return Context.Set<Group>().Where(g => g.CourseId == courseId);
        }

        public IEnumerable<Group> GetGroupsOfAFieldOfStudy(int fieldOfStudyId)
        {
            return Context.Set<Group>().Include(g => g.Cours).Where(g => g.Cours.FieldOfStudyId == fieldOfStudyId).OrderBy(g => g.Cours.SemesterId).ThenBy(g => g.Cours.CourseName).ThenBy(g =>g.Type).ToList();
        }

        public IEnumerable<Group> GetGroupsOfAFieldOfStudy(int fieldOfStudyId, int semesterId)
        {
            return Context.Set<Group>().Include(g => g.Cours).Where(g => g.Cours.FieldOfStudyId == fieldOfStudyId && g.Cours.SemesterId == semesterId).OrderBy(g => g.Cours.CourseName).ThenBy(g => g.Type).ToList();
        }
    }
}