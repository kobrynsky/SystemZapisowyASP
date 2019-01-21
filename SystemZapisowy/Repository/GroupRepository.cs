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
    }
}