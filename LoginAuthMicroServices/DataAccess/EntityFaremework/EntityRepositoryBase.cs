using System;
using Microsoft.EntityFrameworkCore;
using LoginAuthMicroServices.Core;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.EntityFaremework
{
    public class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
       where TEntity : class, IEntity
       where TContext : DbContext  
    {
        public EntityRepositoryBase(TContext context)
        {
            Context = context;
        }

        protected TContext Context { get; }

        public TEntity Add(TEntity entity)
        {
            return Context.Add(entity).Entity;
        }

        public void Delete(TEntity entity)
        {
            Context.Remove(entity);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            return Context.Set<TEntity>().FirstOrDefault(filter);
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            return filter == null
                 ? Context.Set<TEntity>().AsNoTracking()
                 : Context.Set<TEntity>().Where(filter).AsNoTracking();
        }


        public TEntity Update(TEntity entity)
        {
            Context.Update(entity);
            return entity;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }
    }
}
