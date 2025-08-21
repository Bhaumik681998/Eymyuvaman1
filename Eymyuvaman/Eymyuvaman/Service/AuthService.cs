using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.UserMaster;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Eymyuvaman.Service
{
    public class AuthService : IAuthRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthService(AppDBContext appDBContext, IConfiguration configuration)
        {
            _dbContext = appDBContext;
            _configuration = configuration;
        }

        #region :: LoginUser ::
        public async Task<BaseResponseObject<UserLoginResponseVM>> LoginUser(UserLoginVM entity)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(entity.Password) || string.IsNullOrWhiteSpace(entity.MobileNo))
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.EmptyCredentials };

                var password = Encrypting.HashPassword(entity.Password);
                var user = await _dbContext.UserMaster.Where(x => x.MobileNo == entity.MobileNo && x.Password == password).FirstOrDefaultAsync();
                if (user == null)
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.InvalidCredentials };

                if (user.Status != true)
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.UserInActive };

                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.MobileNo)
                };
                double expireTime = Convert.ToDouble(_configuration["Token:ExpiredTime"]);
                DateTime setExpiredTime = DateTime.Now.AddMinutes(expireTime);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = setExpiredTime,
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = creds
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                string jwtToken = tokenHandler.WriteToken(token);

                return new BaseResponseObject<UserLoginResponseVM>
                {
                    Success = true,
                    Message = ResponseMessage.UserLogin,
                    Data = new UserLoginResponseVM
                    {
                        Token = jwtToken,
                        MobileNo = user.MobileNo,
                        Email = user.Email,
                        ExpireAt = setExpiredTime
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
