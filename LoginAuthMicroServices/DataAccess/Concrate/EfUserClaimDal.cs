using LoginAuthMicroServices.DataAccess.Abstract;
using LoginAuthMicroServices.DataAccess.EntityFaremework;
using LoginAuthMicroServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.Concrate
{
    public class EfUserClaimDal : EntityRepositoryBase<UserClaim, PgDbContext>, IUserClaimDal
    {
        public EfUserClaimDal(PgDbContext context)
         : base(context)
        {
        }
    }
}
