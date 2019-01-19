using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SystemZapisowy.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //IEnumerable<TEntity> GetOverview(Func<TEntity, bool> predicate = null);
        //TEntity GetDetail(Func<TEntity, bool> predicate);

        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        IEnumerable<TEntity> GetOrdered<TKey>(Expression<Func<TEntity, TKey>> predicate, bool descending = false);

        IEnumerable<TEntity> GetOrdered<TKey>(Expression<Func<TEntity, TKey>> predicate,
            Expression<Func<TEntity, TKey>> thenBy, bool firstDescending = false, bool secondDescending = false);


        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
}

