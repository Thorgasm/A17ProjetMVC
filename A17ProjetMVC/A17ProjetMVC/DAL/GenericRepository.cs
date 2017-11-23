using A17ProjetMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace A17ProjetMVC.DAL
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                //filter est une lambda expression
                query = query.Where(filter);
            }
            //faire les Include
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);

            }
            return query;
        }

        public TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }
    }
}