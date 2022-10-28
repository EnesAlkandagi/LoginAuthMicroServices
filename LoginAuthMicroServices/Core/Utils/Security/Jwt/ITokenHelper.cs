using LoginAuthMicroServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.Core.Utils.Security.Jwt
{

    public interface ITokenHelper
    {
        TAccessToken CreateToken<TAccessToken>(User user) where TAccessToken : IAccessToken, new();

    }

}
