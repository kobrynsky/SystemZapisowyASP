using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
	public class StudentRepository : Repository<Student>, IStudentRepository
	{
	    public StudentRepository(DbContext context) : base(context)
	    {
	    }

        public IEnumerable<Group> GetStudentsGroups(int id)
        {
            return Context.Set<Student>().FirstOrDefault(s => s.UserId == id).StudentsGroups.Select(s => s.Group);
        }

        public Student GetStudentByUserId(int id)
        {
            return Context.Set<Student>().First(s => s.UserId == id);
        }

        public void SignOutStudentFromGroup(int groupId, int userId)
        {
            var studentIndexNumber = Context.Set<Student>().Single(s => s.UserId == userId).IndexNumber;
            var studentGroupToRemove = Context.Set<StudentsGroup>().Single(s => s.IndexNumber == studentIndexNumber && s.GroupId == groupId);
            Context.Set<StudentsGroup>().Remove(studentGroupToRemove);
            Context.Set<Group>().Single(g => g.GroupId == groupId).OccupiedSeats--;
        }

	    public SystemZapisowyEntities SystemZapisowyEntities
	    {
	        get { return Context as SystemZapisowyEntities;}
	    }
    }
}