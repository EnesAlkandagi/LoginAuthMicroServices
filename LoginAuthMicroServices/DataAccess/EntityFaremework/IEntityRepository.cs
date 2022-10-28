using LoginAuthMicroServices.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.EntityFaremework
{
    public interface IEntityRepository<T> where T : class, IEntity
    {
        T Get(Expression<Func<T, bool>> filter = null);

        IEnumerable<T> GetList(Expression<Func<T, bool>> filter = null);

        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        int SaveChanges();
    }
}
