using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Tuya.Pagos.Persistence.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Save(TEntity entidad);
        void AddRange(List<TEntity> entidades);
        void Update(TEntity entidad);
        void Delete(TEntity entidad);
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
        bool Any(Expression<Func<TEntity, bool>> predicate);
    }
}
