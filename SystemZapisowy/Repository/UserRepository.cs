using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class UserRepository: Repository<User>, IUserRepository
    {
        public UserRepository(SystemZapisowyEntities context) : base(context)
        {
        }

        public SystemZapisowyEntities SystemZapisowyEntities
        {
            get { return Context as SystemZapisowyEntities;}
        }
    }
}