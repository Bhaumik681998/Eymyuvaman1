using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.UserMaster;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class UsermasterService : IUserMasterRepository
    {
        private readonly AppDBContext _dbContext;
        public UsermasterService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update User Detail ::
        public async Task<BaseResponse> AddUpdateUserDetail(AddUpdateUserMasterVM entity)
        {
            try
            {

                var isExistEmailAndPhone = await _dbContext.UserMaster.Where(x => x.MobileNo == entity.MobileNo || x.Email == entity.Email).FirstOrDefaultAsync();
                if (isExistEmailAndPhone != null)
                    return new BaseResponse { Success = false, Message = ResponseMessage.EmailAndPhoneAlreadyExist };

                UserMaster? UserDetail = await _dbContext.UserMaster.FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (UserDetail == null)
                {
                    UserDetail = new UserMaster
                    {
                        CreatedDate = DateTime.Now
                    };
                    await _dbContext.UserMaster.AddAsync(UserDetail);
                }
                else
                {
                    UserDetail.UpdatedDate = DateTime.Now;
                    _dbContext.UserMaster.Update(UserDetail);
                }

                UserDetail.MobileNo = entity.MobileNo;
                UserDetail.Email = entity.Email;
                UserDetail.Password = Encrypting.HashPassword(entity.Password);
                UserDetail.Status = entity.Status;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = entity.Id > 0 ? ResponseMessage.UpdateUser : ResponseMessage.AddUser
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get All User Detail 
        public async Task<BaseResponseModel<IEnumerable<UserMasterDetailsVM>>> GetAllUserDetail()
        {
            try
            {
                var UserDetailsList = await (from u in _dbContext.UserMaster
                                             where u.Status == true
                                             select new UserMasterDetailsVM
                                             {
                                                 Id = u.Id,
                                                 MobileNo = u.MobileNo,
                                                 Email = u.Email,
                                                 Password = u.Password,
                                                 Status = u.Status,
                                                 CreatedDate = u.CreatedDate,
                                                 UpdatedDate = u.UpdatedDate
                                             }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<UserMasterDetailsVM>>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    Data = UserDetailsList,
                    TotalRecored = UserDetailsList.Count()
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get User Detail By Id
        public async Task<BaseResponseObject<UserMasterDetailsVM>> GetUserDetailById(int UserId)
        {
            try
            {
                var UserDetails = await (from u in _dbContext.UserMaster
                                         where u.Id == UserId && u.Status == true
                                         select new UserMasterDetailsVM
                                         {
                                             Id = u.Id,
                                             MobileNo = u.MobileNo,
                                             Email = u.Email,
                                             Password = u.Password,
                                             Status = u.Status,
                                             CreatedDate = u.CreatedDate,
                                             UpdatedDate = u.UpdatedDate
                                         }).FirstOrDefaultAsync();

                if (UserDetails == null)
                    return new BaseResponseObject<UserMasterDetailsVM> { Success = false, Message = ResponseMessage.NoDataFound, Data = null };

                return new BaseResponseObject<UserMasterDetailsVM>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    Data = UserDetails
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
