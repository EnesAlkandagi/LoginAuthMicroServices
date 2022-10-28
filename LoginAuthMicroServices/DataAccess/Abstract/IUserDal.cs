using LoginAuthMicroServices.Core;
using LoginAuthMicroServices.DataAccess.EntityFaremework;
using LoginAuthMicroServices.Entity;
using LoginAuthMicroServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(int userId);

    }
}
