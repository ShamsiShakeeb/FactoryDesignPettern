using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IRepository<TEntity>  where TEntity : BaseEntity, new()
    {
         Task<(bool result, string message, string error)> Insert(TEntity model);
         Task<(bool result, string message, string error)> Update(TEntity model);
         Task<(bool result, string message, string error)> Delete(TEntity model);
         IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> expression);
         Task<TEntity> GetEntity(Expression<Func<TEntity, bool>> expression);
         IQueryable<TEntity> Get();
         Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression = null);
    }
}
