using LoginAuthMicroServices.DataAccess.Abstract;
using LoginAuthMicroServices.DataAccess.EntityFaremework;
using LoginAuthMicroServices.Entity;
using LoginAuthMicroServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.Concrate
{
    public class EfUserDal : EntityRepositoryBase<User, PgDbContext>, IUserDal
    {
        public EfUserDal(PgDbContext context)
         : base(context)
        {
        }

        public List<OperationClaim> GetClaims(int userId)
        {
            var result = from operationClaim in Context.OperationClaims
                         join userOperationClaim in Context.UserClaims
                             on operationClaim.Id equals userOperationClaim.ClaimId
                         where userOperationClaim.UserId == userId
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            return result.ToList();
        }
    }
}
