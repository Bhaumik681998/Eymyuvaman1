using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Auth;
using Eymyuvaman.ViewModel.Designation;
using Eymyuvaman.ViewModel.UserMaster;
using Microsoft.AspNetCore.Mvc;
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

                var kishore = await _dbContext.Kishore.Where(x => x.Phone == entity.MobileNo).FirstOrDefaultAsync();

                if (kishore == null)
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.InvalidCredentials };

                if (string.IsNullOrEmpty(kishore.Password) || string.IsNullOrEmpty(kishore.PasswordSalt))
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.InvalidCredentials };

                // Verify password
                bool isValid = PasswordHelper.VerifyPassword(entity.Password, kishore.Password, kishore.PasswordSalt);
                if (!isValid)
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.InvalidCredentials };

                if (kishore.Status != true)
                    return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.UserInActive };

                // JWT Token generate
                var claims = new List<Claim>()
                {
                    new Claim("LoggedInUserId", kishore.KId.ToString()),
                    new Claim("KishoreName", kishore.KishoreName ?? string.Empty),
                    new Claim("AreaID", kishore.AreaID.ToString()),
                    new Claim("KishoreID", kishore.KishoreID ?? string.Empty),
                    new Claim("SurName", kishore.SurName ?? string.Empty),
                    new Claim("FatherName", kishore.FatherName ?? string.Empty),
                    new Claim(ClaimTypes.Email, kishore.Email ?? string.Empty),
                    new Claim(ClaimTypes.MobilePhone, kishore.Phone ?? string.Empty),
                };
                var designationIds = (kishore.DesigID ?? "").Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

                if (designationIds.Any())
                {
                    claims.AddRange(designationIds.Select(id => new Claim("Designation", id.ToString())));
                }
                var designationList = await _dbContext.Designation.Where(d => designationIds.Contains(d.DesigID))
                               .Select(d => new UserDesignationVM
                               {
                                   DesigID = d.DesigID,
                                   Designation = d.DesignationName
                               }).ToListAsync();


                double expireTime = Convert.ToDouble(_configuration["Token:ExpiredTime"] ?? "30");
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
                        MobileNo = kishore.Phone,
                        Email = kishore.Email,
                        KishoreName = kishore.KishoreName + " " + kishore.FatherName + " " + kishore.SurName,
                        AreaId = kishore.AreaID,
                        Designation = designationList,
                        ExpireAt = setExpiredTime
                    }
                };
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public async Task<BaseResponseObject<UserLoginResponseVM>> LoginUser(UserLoginVM entity)
        //{
        //    try
        //    {

        //        if (string.IsNullOrWhiteSpace(entity.Password) || string.IsNullOrWhiteSpace(entity.MobileNo))
        //            return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.EmptyCredentials };

        //        var password = PasswordHelper.HashPassword(entity.Password);
        //        var user = await _dbContext.UserMaster.Where(x => x.MobileNo == entity.MobileNo && x.Password == password).FirstOrDefaultAsync();
        //        if (user == null)
        //            return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.InvalidCredentials };

        //        if (user.Status != true)
        //            return new BaseResponseObject<UserLoginResponseVM> { Success = false, Message = ResponseMessage.UserInActive };

        //        var claims = new List<Claim>()
        //        {
        //            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        //            new Claim(ClaimTypes.Email, user.Email),
        //            new Claim(ClaimTypes.MobilePhone, user.MobileNo)
        //        };
        //        double expireTime = Convert.ToDouble(_configuration["Token:ExpiredTime"]);
        //        DateTime setExpiredTime = DateTime.Now.AddMinutes(expireTime);

        //        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

        //        var tokenDescriptor = new SecurityTokenDescriptor
        //        {
        //            Subject = new ClaimsIdentity(claims),
        //            Expires = setExpiredTime,
        //            Issuer = _configuration["Jwt:Issuer"],
        //            Audience = _configuration["Jwt:Audience"],
        //            SigningCredentials = creds
        //        };
        //        var tokenHandler = new JwtSecurityTokenHandler();
        //        var token = tokenHandler.CreateToken(tokenDescriptor);
        //        string jwtToken = tokenHandler.WriteToken(token);

        //        return new BaseResponseObject<UserLoginResponseVM>
        //        {
        //            Success = true,
        //            Message = ResponseMessage.UserLogin,
        //            Data = new UserLoginResponseVM
        //            {
        //                Token = jwtToken,
        //                MobileNo = user.MobileNo,
        //                Email = user.Email,
        //                ExpireAt = setExpiredTime
        //            }
        //        };
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        #endregion

        #region :: Change Password ::
        public async Task<BaseResponse> ChangePassword(int LoggedInUserId, ChangePasswordVM entity)
        {
            try
            {
                var userDetail = await _dbContext.Kishore.FirstOrDefaultAsync(x => x.KId == LoggedInUserId);
                if (userDetail == null)
                    return new BaseResponse { Success = false, Message = ResponseMessage.UserNotFound };

                if (string.IsNullOrEmpty(userDetail.Password) || string.IsNullOrEmpty(userDetail.PasswordSalt))
                    return new BaseResponse { Success = false, Message = ResponseMessage.StoredPasswordInvalid };

                if (string.IsNullOrEmpty(entity.OldPassword))
                    return new BaseResponse { Success = false, Message = ResponseMessage.StoredPasswordInvalid };

                bool isOldPasswordValid = PasswordHelper.VerifyPassword(entity.OldPassword, userDetail.Password, userDetail.PasswordSalt);
                if (!isOldPasswordValid)
                    return new BaseResponse { Success = false, Message = ResponseMessage.OldPasswordNotMatch };

                if (entity.NewPassword != entity.ConfirmPassword)
                    return new BaseResponse { Success = false, Message = ResponseMessage.NewConfirmPasswordNotMatch };

                var (newHash, newSalt) = PasswordHelper.HashPasswordWithSalt(entity.NewPassword ?? string.Empty);

                userDetail.Password = newHash;
                userDetail.PasswordSalt = newSalt;
                userDetail.UpdatedDate = DateTime.Now;

                _dbContext.Kishore.Update(userDetail);
                await _dbContext.SaveChangesAsync();

                return new BaseResponse { Success = true, Message = ResponseMessage.PasswordChangedSuccess };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
