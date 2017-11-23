using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace A17ProjetMVC.DAL
{
    public interface IGenericRepository<TEntity>
    {
        IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null,
                               Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                               string includeProperties = "");
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void Update(TEntity entityToUpdate);
    }
}