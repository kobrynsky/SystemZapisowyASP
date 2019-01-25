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

	    public SystemZapisowyEntities SystemZapisowyEntities
	    {
	        get { return Context as SystemZapisowyEntities;}
	    }
    }
}