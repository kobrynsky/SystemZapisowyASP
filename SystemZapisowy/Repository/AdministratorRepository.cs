using System.Data.Entity;
using SystemZapisowy.Models;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class AdministratorRepository : Repository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(DbContext context) : base(context)
        {

        }

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }
    }
}