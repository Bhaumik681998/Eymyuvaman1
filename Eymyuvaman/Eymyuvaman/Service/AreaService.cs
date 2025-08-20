using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Area;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class AreaService : IAreaRepository
    {
        private readonly AppDBContext _dbContext;
        public AreaService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Add/Update Area Detail ::
        public async Task<BaseResponse> AddUpdateAreaDetail(AddUpdateAreaDetail entity)
        {
            try
            {
                var isExistsAreaCode = await _dbContext.Area.FirstOrDefaultAsync(x => x.AreaCode == entity.AreaCode);
                if (isExistsAreaCode != null)
                    return new BaseResponse { Success = false, Message = ResponseMessage.AreaCodeAlreadyExists };

                bool isNewArea = false;
                Area? areaDetail = await _dbContext.Area.FirstOrDefaultAsync(a => a.AreaID == entity.AreaID);
                if (areaDetail == null)
                {
                    isNewArea = true;
                    areaDetail = new Area() { };
                    await _dbContext.Area.AddAsync(areaDetail);
                }

                areaDetail.ZoneID = entity.ZoneID;
                areaDetail.AreaName = entity.AreaName;
                areaDetail.Address1 = entity.Address1;
                areaDetail.Address2 = entity.Address2;
                areaDetail.Mandir = entity.Mandir;
                areaDetail.Pincode = entity.Pincode;
                areaDetail.ImagePath = entity.ImagePath;
                areaDetail.AreaCode = entity.AreaCode;
                areaDetail.UserName = entity.UserName;
                areaDetail.UserPassword = Encrypting.HashPassword(entity.UserPassword ?? string.Empty);
                areaDetail.UserEmail = entity.UserEmail;
                areaDetail.UserMobile = entity.UserMobile;
                areaDetail.Status = entity.Status;

                if (!isNewArea)
                    areaDetail.UpdatedDate = DateTime.Now;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNewArea ? ResponseMessage.AddNewAreaDetail : ResponseMessage.UpdateAreaDetail
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All Area Detail ::
        public async Task<BaseResponseModel<IEnumerable<AreaDetailVM>>> GetAllAreaDetail()
        {
            try
            {
                var areaDetailsList = await (from a in _dbContext.Area
                                             join z in _dbContext.Zones on a.ZoneID equals z.ZoneID
                                             join c in _dbContext.City on z.CityId equals c.CityID
                                             where a.Status == true
                                             select new AreaDetailVM()
                                             {
                                                 AreaID = a.AreaID,
                                                 ZoneID = a.ZoneID,
                                                 ZoneHead = z.ZoneHead,
                                                 CityHead = c.CityHead,
                                                 AreaName = a.AreaName,
                                                 Address1 = a.Address1,
                                                 Address2 = a.Address2,
                                                 Mandir = a.Mandir,
                                                 Pincode = a.Pincode,
                                                 AreaCode = a.AreaCode,
                                                 UserName = a.UserName,
                                                 UserEmail = a.UserEmail,
                                                 UserMobile = a.UserMobile,
                                                 Status = a.Status
                                             }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<AreaDetailVM>>
                {
                    Success = areaDetailsList.Any(),
                    Message = areaDetailsList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = areaDetailsList,
                    TotalRecored = areaDetailsList.Count
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get Area Detail By Id ::
        public async Task<BaseResponseObject<AreaDetailVM>> GetAreaDetailById(int AreaId)
        {
            try
            {
                var areaDetails = await (from a in _dbContext.Area
                                         join z in _dbContext.Zones on a.ZoneID equals z.ZoneID
                                         join c in _dbContext.City on z.CityId equals c.CityID
                                         where a.AreaID == AreaId && a.Status == true
                                         select new AreaDetailVM()
                                         {
                                             AreaID = a.AreaID,
                                             ZoneID = a.ZoneID,
                                             ZoneHead = z.ZoneHead,
                                             CityHead = c.CityHead,
                                             AreaName = a.AreaName,
                                             Address1 = a.Address1,
                                             Address2 = a.Address2,
                                             Mandir = a.Mandir,
                                             Pincode = a.Pincode,
                                             AreaCode = a.AreaCode,
                                             UserName = a.UserName,
                                             UserEmail = a.UserEmail,
                                             UserMobile = a.UserMobile,
                                             Status = a.Status
                                         }).FirstOrDefaultAsync();

                return new BaseResponseObject<AreaDetailVM>
                {
                    Success = areaDetails != null,
                    Message = areaDetails != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = areaDetails
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
