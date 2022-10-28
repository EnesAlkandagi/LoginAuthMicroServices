using LoginAuthMicroServices.DataAccess.EntityFaremework;
using LoginAuthMicroServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.Abstract
{
    public interface IUserClaimDal: IEntityRepository<UserClaim>
    {

    }
}
