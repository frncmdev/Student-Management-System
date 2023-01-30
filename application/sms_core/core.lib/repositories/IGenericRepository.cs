using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace core.lib.repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);        
        public Task<IEnumerable<TEntity>> GetAll();
        public void Create(TEntity entity);
        public void CreateRange(IEnumerable<TEntity> entities);
        public void Update(TEntity entity);
        public void Delete(TEntity entity);
        public void DeleteRange(IEnumerable<TEntity> entities);
    }
}