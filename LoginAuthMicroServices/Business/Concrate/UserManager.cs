using LoginAuthMicroServices.Business.Abstract;
using LoginAuthMicroServices.Core.Utils.Results;
using LoginAuthMicroServices.Core.Utils.Security.Hashing;
using LoginAuthMicroServices.Core.Utils.Security.Jwt;
using LoginAuthMicroServices.DataAccess.Abstract;
using LoginAuthMicroServices.Entity;
using LoginAuthMicroServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginAuthMicroServices.Business.Concrate
{
    public class UserManager : IUserService
    {

        private readonly IUserDal _userDal;
        private readonly IUserClaimDal _userClaimDal;
        private readonly ITokenHelper _tokenHelper;

        public UserManager(IUserDal userDal, ITokenHelper tokenHelper, IUserClaimDal userClaimDal)
        {
            _userDal = userDal;
            _tokenHelper = tokenHelper;
            _userClaimDal = userClaimDal;
        }

        public IDataResult<AccessToken> Login(LoginModel loginModel)
        {
            var user = _userDal.Get(u => u.UserName == loginModel.UserName);

            if (user == null)
            {
                return new ErrorDataResult<AccessToken>("User not found");
            }

            if (!HashingHelper.VerifyPasswordHash(loginModel.Password, user.PasswordSalt, user.PasswordHash))
            {
                return new ErrorDataResult<AccessToken>("Password invalid");
            }

            var claims = _userDal.GetClaims(user.Id);

            var accessToken = _tokenHelper.CreateToken<AccessToken>(user);
            accessToken.Claims = claims.Select(x => x.Name).ToList();

            return new SuccessDataResult<AccessToken>(accessToken);
        }

        public IResult Register(RegisterModel registerModel)
        {
            var isThereAnyUser = _userDal.Get(u => u.UserName == registerModel.UserName);

            if (isThereAnyUser != null)
            {
                return new ErrorResult("Username exist");
            }

            HashingHelper.CreatePasswordHash(registerModel.Password, out var passwordSalt, out var passwordHash);
            var user = new User
            {
                UserName = registerModel.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

            };

            var addedUser = _userDal.Add(user);
            _userDal.SaveChanges();

            var userClaim = new UserClaim
            {
                UserId = addedUser.Id,
                ClaimId = 1
            };

            _userClaimDal.Add(userClaim);
            _userClaimDal.SaveChanges();


            return new SuccessResult("User added");
        }
    }
}
