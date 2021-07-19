using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Tuya.Pagos.Persistence.Infraestructure;
using Tuya.Pagos.Persistence.Interfaces.Repositories;

namespace Tuya.Pagos.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected DbContext DbContext => DbFactory.Init();

        private readonly DbSet<TEntity> _dbSet;

        public Repository(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }

        public void Update(TEntity entidad)
        {
            _dbSet.Attach(entidad);
            DbContext.Entry(entidad).State = EntityState.Modified;
        }

        public void Save(TEntity entidad)
        {
            _dbSet.Add(entidad);
        }
        

        public void AddRange(List<TEntity> entidades)
        {
            _dbSet.AddRange(entidades);
        }

        public void Delete(TEntity entidad)
        {
            _dbSet.Remove(entidad);
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }
        
        public IQueryable<TEntity> GetAll()
        {
            return _dbSet.Select(x => x);
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
