using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model.Event;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EventDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

namespace Eymyuvaman.Service
{
    public class EventService : IEventRepository
    {
        private readonly AppDBContext _dbContext;
        public EventService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Event ::

        #region :: Add/Update Event Detail ::
        public async Task<BaseResponse> AddUpdateEvent(AddUpdateEventVM entity)
        {
            try
            {
                bool isNewEvent = false;
                Evant? evantDetail = _dbContext.Evant.FirstOrDefault(x => x.EvantId == entity.EventId);
                if (evantDetail == null)
                {
                    isNewEvent = true;
                    evantDetail = new Evant()
                    {
                        EventName = entity.EventName,
                        Active = entity.Active
                    };
                    await _dbContext.Evant.AddAsync(evantDetail);
                }
                else
                {
                    evantDetail.EventName = entity.EventName;
                    evantDetail.Active = entity.Active;

                    _dbContext.Evant.Update(evantDetail);
                }
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEvent,
                    Message = isNewEvent ? ResponseMessage.AddNewEventDetail : ResponseMessage.UpdateEventDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Event ::
        public async Task<BaseResponseModel<IEnumerable<EventVM>>> GetAllEvent()
        {
            try
            {
                var evantList = await _dbContext.Evant.Where(x => x.Active == 1)
                    .Select(e => new EventVM()
                    {
                        EventId = e.EvantId,
                        EventName = e.EventName,
                        Active = e.Active
                    }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EventVM>>
                {
                    Success = evantList.Any(),
                    Message = evantList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantList,
                    TotalRecored = evantList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Event By Id ::
        public async Task<BaseResponseObject<EventVM>> GetEventById(int EventId)
        {
            try
            {
                var evantDetail = await _dbContext.Evant.Where(x => x.EvantId == EventId && x.Active == 1)
                    .Select(e => new EventVM()
                    {
                        EventId = e.EvantId,
                        EventName = e.EventName,
                        Active = e.Active
                    }).AsNoTracking().FirstOrDefaultAsync();
                return new BaseResponseObject<EventVM>
                {
                    Success = evantDetail != null,
                    Message = evantDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region :: Event Area ::
        public async Task<BaseResponse> AddUpdateEventAreaDetail(AddUpdateEventAreaVM entity)
        {
            try
            {
                bool isNewEventArea = false;
                EvantArea? evantAreaDetail = _dbContext.EvantArea.FirstOrDefault(x => x.Id == entity.Id);
                if (evantAreaDetail == null)
                {
                    isNewEventArea = true;
                    evantAreaDetail = new EvantArea()
                    {
                        EventId = entity.EventId,
                        AreaId = entity.AreaId,
                        Flag = entity.Flag
                    };
                    await _dbContext.EvantArea.AddAsync(evantAreaDetail);
                }
                else
                {
                    evantAreaDetail.EventId = entity.EventId;
                    evantAreaDetail.AreaId = entity.AreaId;
                    evantAreaDetail.Flag = entity.Flag;

                    _dbContext.EvantArea.Update(evantAreaDetail);
                }
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEventArea,
                    Message = isNewEventArea ? ResponseMessage.AddNewEventAreaDetail : ResponseMessage.UpdateEventAreaDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region ::Get All Event Area ::
        public async Task<BaseResponseModel<IEnumerable<EventAreaDetailVM>>> GetAllEventAreaDetail()
        {
            try
            {
                var evantAreaList = await _dbContext.EvantArea.Select(e => new EventAreaDetailVM()
                {
                    Id = e.Id,
                    EventId = e.EventId,
                    AreaId = e.AreaId,
                    Flag = e.Flag
                }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EventAreaDetailVM>>
                {
                    Success = evantAreaList.Any(),
                    Message = evantAreaList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantAreaList,
                    TotalRecored = evantAreaList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Event Area By Id ::
        public async Task<BaseResponseObject<EventAreaDetailVM>> GetEventAreaDetailById(int EventAreaId)
        {
            try
            {
                var evantAreaDetail = await _dbContext.EvantArea.Where(x => x.Id == EventAreaId)
                    .Select(e => new EventAreaDetailVM()
                    {
                        Id = e.Id,
                        EventId = e.EventId,
                        AreaId = e.AreaId,
                        Flag = e.Flag
                    }).FirstOrDefaultAsync();
                return new BaseResponseObject<EventAreaDetailVM>
                {
                    Success = evantAreaDetail != null,
                    Message = evantAreaDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantAreaDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region :: Event Detial ::

        #region :: Add/Update Event Detail ::
        public async Task<BaseResponse> AddUpdateEventDetail(AddUpdateEventDetialVM entity)
        {
            try
            {
                EvantDetial? evantDetail = await _dbContext.EvantDetial.FirstOrDefaultAsync(x => x.EDetailId == entity.EDetailId);

                bool isNewEventDetail = evantDetail == null;

                if (isNewEventDetail)
                {
                    evantDetail = new EvantDetial();
                    await _dbContext.EvantDetial.AddAsync(evantDetail);
                }

                evantDetail!.EvantId = entity.EventId;
                evantDetail.FieldTitle = entity.FieldTitle;
                evantDetail.FiledType = entity.FiledType;
                evantDetail.SequenceNo = entity.SequenceNo;
                evantDetail.DefaultValue = entity.DefaultValue;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEventDetail,
                    Message = isNewEventDetail ? ResponseMessage.AddNewEventEntryDetail : ResponseMessage.UpdateEventEntryDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Event ::
        public async Task<BaseResponseModel<IEnumerable<EventDetialVM>>> GetAllEventDetail()
        {
            try
            {
                var evantDetailList = await (from ed in _dbContext.EvantDetial
                                             join ev in _dbContext.Evant on ed.EvantId equals ev.EvantId
                                             select new EventDetialVM
                                             {
                                                 EDetailId = ed.EDetailId,
                                                 EventId = ed.EvantId,
                                                 EventName = ev.EventName,
                                                 FieldTitle = ed.FieldTitle,
                                                 FiledType = ed.FiledType,
                                                 SequenceNo = ed.SequenceNo,
                                                 DefaultValue = ed.DefaultValue
                                             }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EventDetialVM>>
                {
                    Success = evantDetailList.Any(),
                    Message = evantDetailList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantDetailList,
                    TotalRecored = evantDetailList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Event By Id ::
        public async Task<BaseResponseObject<EventDetialVM>> GetEventDetailById(int EventDetailId)
        {
            try
            {
                var evantDetail = await (from ed in _dbContext.EvantDetial
                                         join ev in _dbContext.Evant on ed.EvantId equals ev.EvantId
                                         where ed.EDetailId == EventDetailId
                                         select new EventDetialVM
                                         {
                                             EDetailId = ed.EDetailId,
                                             EventId = ed.EvantId,
                                             EventName = ev.EventName,
                                             FieldTitle = ed.FieldTitle,
                                             FiledType = ed.FiledType,
                                             SequenceNo = ed.SequenceNo,
                                             DefaultValue = ed.DefaultValue
                                         }).FirstOrDefaultAsync();

                return new BaseResponseObject<EventDetialVM>
                {
                    Success = evantDetail != null,
                    Message = evantDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #endregion

        #region :: Event Entry ::

        #region :: Add/Update Event Entry Detail ::
        public async Task<BaseResponse> AddUpdateEventEntryDetail(AddUpdateEventEntryVM entity)
        {
            try
            {
                EvantEntry? evantEntryDetail = await _dbContext.EvantEntry.FirstOrDefaultAsync(x => x.EEntryId == entity.EEntryId);

                bool isNewEventEntryDetail = evantEntryDetail == null;

                if (isNewEventEntryDetail)
                {
                    evantEntryDetail = new EvantEntry();
                    await _dbContext.EvantEntry.AddAsync(evantEntryDetail);
                }

                evantEntryDetail!.EvantId = entity.EventId;
                evantEntryDetail.EDetailId = entity.EDetailId;
                evantEntryDetail.KishorId = entity.KishorId;
                evantEntryDetail.Value = entity.Value;
                evantEntryDetail.Completed = entity.Completed;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEventEntryDetail,
                    Message = isNewEventEntryDetail ? ResponseMessage.AddNewEventEntryDetail : ResponseMessage.UpdateEventEntryDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Event ::
        public async Task<BaseResponseModel<IEnumerable<EventEntryDetailVM>>> GetAllEventEntryDetail()
        {
            try
            {
                var evantEntryDetailList = await (from ee in _dbContext.EvantEntry
                                                  join ev in _dbContext.Evant on ee.EvantId equals ev.EvantId
                                                  join ed in _dbContext.EvantDetial on ee.EDetailId equals ed.EDetailId
                                                  join k in _dbContext.Kishore on ee.KishorId equals k.KId
                                                  select new EventEntryDetailVM
                                                  {
                                                      EEntryId = ee.EDetailId,
                                                      EventId = ee.EvantId,
                                                      EventName = ev.EventName,
                                                      EDetailId = ee.EDetailId,
                                                      FieldTitle = ed.FieldTitle,
                                                      FieldType = ed.FiledType,
                                                      KishorId = ee.KishorId,
                                                      KishoreName = k.KishoreName + " " + k.FatherName + " " + k.SurName,
                                                      Value = ee.Value,
                                                      Completed = ee.Completed
                                                  }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EventEntryDetailVM>>
                {
                    Success = evantEntryDetailList.Any(),
                    Message = evantEntryDetailList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantEntryDetailList,
                    TotalRecored = evantEntryDetailList.Count
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Event By Id ::
        public async Task<BaseResponseObject<EventEntryDetailVM>> GetEventEntryDetailById(int EventDetailId)
        {
            try
            {
                var evantEntryDetail = await (from ee in _dbContext.EvantEntry
                                              join ev in _dbContext.Evant on ee.EvantId equals ev.EvantId
                                                  join ed in _dbContext.EvantDetial on ee.EDetailId equals ed.EDetailId
                                                  join k in _dbContext.Kishore on ee.KishorId equals k.KId
                                                  select new EventEntryDetailVM
                                                  {
                                                      EEntryId = ee.EDetailId,
                                                      EventId = ee.EvantId,
                                                      EventName = ev.EventName,
                                                      EDetailId = ee.EDetailId,
                                                      FieldTitle = ed.FieldTitle,
                                                      FieldType = ed.FiledType,
                                                      KishorId = ee.KishorId,
                                                      KishoreName = k.KishoreName + " " + k.FatherName + " " + k.SurName,
                                                      Value = ee.Value,
                                                      Completed = ee.Completed
                                                  }).AsNoTracking().FirstOrDefaultAsync();


                return new BaseResponseObject<EventEntryDetailVM>
                {
                    Success = evantEntryDetail != null,
                    Message = evantEntryDetail != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = evantEntryDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #endregion
    }
}
