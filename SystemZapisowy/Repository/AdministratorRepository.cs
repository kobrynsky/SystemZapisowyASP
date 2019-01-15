using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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