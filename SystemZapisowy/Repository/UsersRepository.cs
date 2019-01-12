using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SystemZapisowy.Repository.Interfaces;

namespace SystemZapisowy.Repository
{
    public class UsersRepository : IRepository<Users>
    {
        private readonly SystemZapisowyEntities _db = new SystemZapisowyEntities();

        public void Add(Users entity)
        {
            _db.Users.Add(entity);
        }
        public void Delete(Users entity)
        {
            _db.Users.Remove(entity);
        }
        public Users GetDetail(Func<Users, bool> predicate)
        {
            return _db.Users.FirstOrDefault(predicate);
        }
        public IEnumerable<Users> GetOverview(Func<Users, bool> predicate = null)
        {
            if (predicate != null)
                return _db.Users.Where(predicate);
            return _db.Users;
        }
        internal void SaveChanges()
        {
            _db.SaveChanges();
        }
    }
}