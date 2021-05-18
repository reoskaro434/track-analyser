using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TrackAnalyser.DataAccess.RepositoryPattern
{
    public interface IRepository<TEntity> where TEntity:class
    {
        Task<TEntity> GetAsync(int id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        void AddAsync(TEntity entity);
        void AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void ReloadAsync(TEntity entity);
    }
}
