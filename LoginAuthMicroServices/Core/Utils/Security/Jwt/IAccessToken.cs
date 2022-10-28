using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.Core.Utils.Security.Jwt
{
    public interface IAccessToken
    {     
            DateTime Expiration { get; set; }
            string Token { get; set; }    
    }
}
