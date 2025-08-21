using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class SabhaSessionService : ISabhaSessionRepository
    {
        private readonly AppDBContext _dbContext;

        public SabhaSessionService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update Sabha Session ::
        public async Task<BaseResponse> AddUpdateSabhaSession(AddUpdateSabhaSession entity)
        {
            try
            {
                SabhaSession? sabhaSession = await _dbContext.SabhaSession.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (sabhaSession == null)
                {
                    sabhaSession = new SabhaSession()
                    {
                        SessionTitle = entity.SessionTitle,
                        Regular_Evant = entity.Regular_Event,
                        Regular_Evant_Id = entity.Regular_Event_Id,
                        SabhaDate = entity.SabhaDate,
                        StartTime = entity.StartTime,
                        EndTime = entity.EndTime,
                        TimeFlag = entity.TimeFlag,
                        Description = entity.Description,
                        Dislpay_Order = entity.Dislpay_Order,
                        Active = entity.Active,
                        SabhaCode = entity.SabhaCode
                    };
                    await _dbContext.SabhaSession.AddAsync(sabhaSession);
                }
                else
                {
                    sabhaSession.SessionTitle = entity.SessionTitle;
                    sabhaSession.Regular_Evant = entity.Regular_Event;
                    sabhaSession.Regular_Evant_Id = entity.Regular_Event_Id;
                    sabhaSession.SabhaDate = entity.SabhaDate;
                    sabhaSession.StartTime = entity.StartTime;
                    sabhaSession.EndTime = entity.EndTime;
                    sabhaSession.TimeFlag = entity.TimeFlag;
                    sabhaSession.Description = entity.Description;
                    sabhaSession.Dislpay_Order = entity.Dislpay_Order;
                    sabhaSession.Active = entity.Active;
                    sabhaSession.SabhaCode = entity.SabhaCode;

                    _dbContext.SabhaSession.Update(sabhaSession);
                }

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = entity.Id > 0 ? ResponseMessage.UpdateSabhaSession : ResponseMessage.AddSabhaSession
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All Sabha Details
        public async Task<BaseResponseModel<IEnumerable<SabhaSessionDetailVM>>> GetAllSabhaSessionDetail()
        {
            try
            {
                var sabhaSessionList = await _dbContext.SabhaSession.Where(x => x.Active == 1)
                .Select(s => new SabhaSessionDetailVM
                {
                    Id = s.Id,
                    SessionTitle = s.SessionTitle,
                    Regular_Event = s.Regular_Evant,
                    Regular_Event_Id = s.Regular_Evant_Id,
                    SabhaDate = s.SabhaDate,
                    StartTime = s.StartTime,
                    EndTime = s.EndTime,
                    TimeFlag = s.TimeFlag,
                    Description = s.Description,
                    Dislpay_Order = s.Dislpay_Order,
                    SabhaCode = s.SabhaCode
                }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<SabhaSessionDetailVM>>
                {
                    Success = sabhaSessionList.Any(),
                    Message = sabhaSessionList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = sabhaSessionList,
                    TotalRecored = sabhaSessionList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Sabah Detail By Id
        public async Task<BaseResponseObject<SabhaSessionDetailVM>> GetSabhaSessionDetailById(int SabhaSessionId)
        {
            try
            {
                var sabhaSessionDetail = await _dbContext.SabhaSession.Where(x => x.Id == SabhaSessionId && x.Active == 1)
               .Select(s => new SabhaSessionDetailVM
               {
                   Id = s.Id,
                   SessionTitle = s.SessionTitle,
                   Regular_Event = s.Regular_Evant,
                   Regular_Event_Id = s.Regular_Evant_Id,
                   SabhaDate = s.SabhaDate,
                   StartTime = s.StartTime,
                   EndTime = s.EndTime,
                   TimeFlag = s.TimeFlag,
                   Description = s.Description,
                   Dislpay_Order = s.Dislpay_Order,
                   SabhaCode = s.SabhaCode
               }).FirstOrDefaultAsync();

                return new BaseResponseObject<SabhaSessionDetailVM>
                {
                    Success = sabhaSessionDetail != null,
                    Message = sabhaSessionDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = sabhaSessionDetail
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
