using TrackAnalyser.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace TrackAnalyser.DataAccess.RepositoryPattern
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _db;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(TEntity entity)
        {
            _db.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _db.AddRange(entities);
        }

        public void Reload(TEntity entity)
        {
            _db.Entry(entity).GetDatabaseValues();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }

        public TEntity Get(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _db.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            _db.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _db.RemoveRange(entities);
        }

        public void Update(TEntity entity)
        {
            _db.Update(entity);
        }
    }
}
