using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.NewYuvakSabhaAttend;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class NewYuvakSabhaAttendService : INewYuvakSabhaAttendRepository
    {
        private readonly AppDBContext _dbContext;
        public NewYuvakSabhaAttendService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update New Yuvak Sabha Attend ::
        public async Task<BaseResponse> AddUpdateNewYuvakSabhaAttend(AddUpdateYuvakSabhaAttendVM entity)
        {
            try
            {
                bool isNew = false;

                var yuvakSabhaAttend = await _dbContext.NewYuvakSabhaAttend.FirstOrDefaultAsync(x => x.AttendID == entity.AttendID);

                if (yuvakSabhaAttend == null)
                {
                    isNew = true;
                    yuvakSabhaAttend = new NewYuvakSabhaAttend
                    {
                        NewYuvakId = entity.NewYuvakId,
                        SabhaSessionId = entity.SabhaSessionId,
                        EntryTime = entity.EntryTime
                    };
                    await _dbContext.NewYuvakSabhaAttend.AddAsync(yuvakSabhaAttend);
                }
                else
                {
                    yuvakSabhaAttend.NewYuvakId = entity.NewYuvakId;
                    yuvakSabhaAttend.SabhaSessionId = entity.SabhaSessionId;
                    yuvakSabhaAttend.EntryTime = entity.EntryTime;

                    _dbContext.NewYuvakSabhaAttend.Update(yuvakSabhaAttend);
                }

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNew ? ResponseMessage.AddNewYuvakSabhaAttend : ResponseMessage.UpdateNewYuvakSabhaAttend
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get All New Yuvak Sabha Attend Detail ::
        public async Task<BaseResponseModel<IEnumerable<YuvakSabhaAttendDetailVM>>> GetAllNewyuvakSabhaAttendDetail()
        {
            try
            {
                var newYuvakSabhaAttendlist = await (from sa in _dbContext.NewYuvakSabhaAttend
                                                     join yd in _dbContext.NewYuvakDetails on sa.NewYuvakId equals yd.NewYuvakId
                                                     join ss in _dbContext.SabhaSession on sa.SabhaSessionId equals ss.Id
                                                     select new YuvakSabhaAttendDetailVM
                                                     {
                                                         SabhaAttendId = sa.AttendID,
                                                         NewYuvakName = yd.KishoreName + " " + yd.FatherName + " " + yd.SurName,
                                                         SabhaSessionTitle = ss.SessionTitle,
                                                         EntryTime = sa.EntryTime
                                                     }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<YuvakSabhaAttendDetailVM>>
                {
                    Success = true,
                    Data = newYuvakSabhaAttendlist,
                    Message = ResponseMessage.DataRetrieved,
                    TotalRecored = newYuvakSabhaAttendlist.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get new Yuvak Sabha Attend Detail By Id ::
        public async Task<BaseResponseObject<YuvakSabhaAttendDetailVM>> GetNewyuvakSabhaAttendDetailById(int AttendId)
        {
            try
            {
                var newYuvakSabhaAttendDetail = await (from sa in _dbContext.NewYuvakSabhaAttend
                                                       join yd in _dbContext.NewYuvakDetails on sa.NewYuvakId equals yd.NewYuvakId
                                                       join ss in _dbContext.SabhaSession on sa.SabhaSessionId equals ss.Id
                                                       where sa.AttendID == AttendId
                                                       select new YuvakSabhaAttendDetailVM
                                                       {
                                                           SabhaAttendId = sa.AttendID,
                                                           NewYuvakName = yd.KishoreName + " " + yd.FatherName + " " + yd.SurName,
                                                           SabhaSessionTitle = ss.SessionTitle,
                                                           EntryTime = sa.EntryTime
                                                       }).FirstOrDefaultAsync();

                return new BaseResponseObject<YuvakSabhaAttendDetailVM>
                {
                    Success = newYuvakSabhaAttendDetail != null,
                    Message = newYuvakSabhaAttendDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = newYuvakSabhaAttendDetail
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
