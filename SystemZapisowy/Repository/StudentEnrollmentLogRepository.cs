using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class StudentEnrollmentLogRepository : Repository<StudentEnrollmentLog>, IStudentEnrollmentLogRepository
    {
        public StudentEnrollmentLogRepository(DbContext context) : base(context)
        {
        }

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }

        public void RemoveByGroupId(int groupId)
        {
            var logs = SystemZapisowyEntities.StudentEnrollmentLogs.Where(x => x.GroupId == groupId);
            if (logs.Any())
            {
                SystemZapisowyEntities.StudentEnrollmentLogs.RemoveRange(logs);
                SystemZapisowyEntities.SaveChanges();
            }
        }
    }
}