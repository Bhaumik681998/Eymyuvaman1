using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.NewYuvakDetails;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class YuvakService : IYuvakRepository
    {
        private readonly AppDBContext _dbContext;

        public YuvakService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update New Yuvak Detail::
        public async Task<BaseResponse> AddUpdateNewYuvakDetail(AddUpdateNewYuvakDetail entity)
        {
            try
            {
                bool isNew = false;
                NewYuvakDetails? yuvakDetails = await _dbContext.NewYuvakDetails.FirstOrDefaultAsync(x => x.NewYuvakId == entity.NewYuvakId);
                if (yuvakDetails == null)
                {
                    isNew = true;
                    yuvakDetails = new NewYuvakDetails
                    {
                        NewYuvakId = entity.NewYuvakId,
                        RegistrationDate = DateTime.Now
                    };
                    await _dbContext.NewYuvakDetails.AddAsync(yuvakDetails);
                }
                else
                {
                    _dbContext.NewYuvakDetails.Update(yuvakDetails);
                }

                yuvakDetails.KishoreName = entity.KishoreName;
                yuvakDetails.FatherName = entity.FatherName;
                yuvakDetails.SurName = entity.SurName;
                yuvakDetails.Address1 = entity.Address1;
                yuvakDetails.Address2 = entity.Address2;
                yuvakDetails.Pincode = entity.Pincode;
                yuvakDetails.Phone = entity.Phone;
                yuvakDetails.Area = entity.Area;
                yuvakDetails.DOB = entity.DOB;
                yuvakDetails.Status = entity.Status;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNew ? ResponseMessage.AddNewYuvak : ResponseMessage.UpdateYuvakDetail
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All yuvak Detail ::
        public async Task<BaseResponseModel<IEnumerable<YuvakDetailVM>>> GetAllYuvakDetail()
        {
            try
            {
                var yuvakDetailsList = await _dbContext.NewYuvakDetails.Where(y => y.Status == true)
                    .Select(y => new YuvakDetailVM
                    {
                        NewYuvakId = y.NewYuvakId,
                        KishoreName = y.KishoreName,
                        FatherName = y.FatherName,
                        SurName = y.SurName,
                        Address1 = y.Address1,
                        Address2 = y.Address2,
                        Pincode = y.Pincode,
                        Phone = y.Phone,
                        Area = y.Area,
                        DOB = y.DOB,
                        RegistrationDate = y.RegistrationDate,
                        Status = y.Status
                    }).ToListAsync();

                return new BaseResponseModel<IEnumerable<YuvakDetailVM>>
                {
                    Success = yuvakDetailsList.Any(),
                    Message = yuvakDetailsList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = yuvakDetailsList,
                    TotalRecored = yuvakDetailsList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Yuvak Detail By Id ::
        public async Task<BaseResponseObject<YuvakDetailVM>> GetYuvakDetailById(string YuvakId)
        {
            try
            {
                var yuvakDetail = await _dbContext.NewYuvakDetails.Where(y => y.NewYuvakId == YuvakId && y.Status == true)
                    .Select(y => new YuvakDetailVM
                    {
                        NewYuvakId = y.NewYuvakId,
                        KishoreName = y.KishoreName,
                        FatherName = y.FatherName,
                        SurName = y.SurName,
                        Address1 = y.Address1,
                        Address2 = y.Address2,
                        Pincode = y.Pincode,
                        Phone = y.Phone,
                        Area = y.Area,
                        DOB = y.DOB,
                        RegistrationDate = y.RegistrationDate,
                        Status = y.Status
                    }).FirstOrDefaultAsync();

                return new BaseResponseObject<YuvakDetailVM>
                {
                    Success = yuvakDetail != null,
                    Message = yuvakDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = yuvakDetail
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
