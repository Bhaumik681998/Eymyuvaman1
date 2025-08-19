using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model.Evant;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic.FileIO;

namespace Eymyuvaman.Service
{
    public class EvantService : IEvantRepository
    {
        private readonly AppDBContext _dbContext;
        public EvantService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Evant ::

        #region :: Add/Update Evant Detail ::
        public async Task<BaseResponse> AddUpdateEvant(AddUpdateEvantVM entity)
        {
            try
            {
                bool isNewEvant = false;
                Evant? evantDetail = _dbContext.Evant.FirstOrDefault(x => x.EvantId == entity.EvantId);
                if (evantDetail == null)
                {
                    isNewEvant = true;
                    evantDetail = new Evant()
                    {
                        EvantName = entity.EvantName,
                        Active = entity.Active
                    };
                    await _dbContext.Evant.AddAsync(evantDetail);
                }
                else
                {
                    evantDetail.EvantName = entity.EvantName;
                    evantDetail.Active = entity.Active;

                    _dbContext.Evant.Update(evantDetail);
                }
                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEvant,
                    Message = isNewEvant ? ResponseMessage.AddNewEvantDetail : ResponseMessage.UpdateEvantDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Evant ::
        public async Task<BaseResponseModel<IEnumerable<EvantVM>>> GetAllEvant()
        {
            try
            {
                var evantList = await _dbContext.Evant.Where(x => x.Active == 1)
                    .Select(e => new EvantVM()
                    {
                        EvantId = e.EvantId,
                        EvantName = e.EvantName,
                        Active = e.Active
                    }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EvantVM>>
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

        #region :: Get Evant By Id ::
        public async Task<BaseResponseObject<EvantVM>> GetEvantById(int EvantId)
        {
            try
            {
                var evantDetail = await _dbContext.Evant.Where(x => x.EvantId == EvantId && x.Active == 1)
                    .Select(e => new EvantVM()
                    {
                        EvantId = e.EvantId,
                        EvantName = e.EvantName,
                        Active = e.Active
                    }).AsNoTracking().FirstOrDefaultAsync();
                return new BaseResponseObject<EvantVM>
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

        #region :: Evant Area ::
        public async Task<BaseResponse> AddUpdateEvantAreaDetail(AddUpdateEvantAreaVM entity)
        {
            try
            {
                bool isNewEvantArea = false;
                EvantArea? evantAreaDetail = _dbContext.EvantArea.FirstOrDefault(x => x.Id == entity.Id);
                if (evantAreaDetail == null)
                {
                    isNewEvantArea = true;
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
                    Success = isNewEvantArea,
                    Message = isNewEvantArea ? ResponseMessage.AddNewEvantAreaDetail : ResponseMessage.UpdateEvantAreaDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #region ::Get All Evant Area ::
        public async Task<BaseResponseModel<IEnumerable<EvantAreaDetailVM>>> GetAllEvantAreaDetail()
        {
            try
            {
                var evantAreaList = await _dbContext.EvantArea.Select(e => new EvantAreaDetailVM()
                {
                    Id = e.Id,
                    EventId = e.EventId,
                    AreaId = e.AreaId,
                    Flag = e.Flag
                }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EvantAreaDetailVM>>
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

        #region :: Get Evant Area By Id ::
        public async Task<BaseResponseObject<EvantAreaDetailVM>> GetEvantAreaDetailById(int EvantAreaId)
        {
            try
            {
                var evantAreaDetail = await _dbContext.EvantArea.Where(x => x.Id == EvantAreaId)
                    .Select(e => new EvantAreaDetailVM()
                    {
                        Id = e.Id,
                        EventId = e.EventId,
                        AreaId = e.AreaId,
                        Flag = e.Flag
                    }).FirstOrDefaultAsync();
                return new BaseResponseObject<EvantAreaDetailVM>
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

        #region :: Evant Detial ::

        #region :: Add/Update Evant Detail ::
        public async Task<BaseResponse> AddUpdateEvantDetail(AddUpdateEvantDetialVM entity)
        {
            try
            {
                EvantDetial? evantDetail = await _dbContext.EvantDetial.FirstOrDefaultAsync(x => x.EDetailId == entity.EDetailId);

                bool isNewEvantDetail = evantDetail == null;

                if (isNewEvantDetail)
                {
                    evantDetail = new EvantDetial();
                    await _dbContext.EvantDetial.AddAsync(evantDetail);
                }

                evantDetail!.EvantId = entity.EvantId;
                evantDetail.FieldTitle = entity.FieldTitle;
                evantDetail.FiledType = entity.FiledType;
                evantDetail.SequenceNo = entity.SequenceNo;
                evantDetail.DefaultValue = entity.DefaultValue;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEvantDetail,
                    Message = isNewEvantDetail ? ResponseMessage.AddNewEvantEntryDetail : ResponseMessage.UpdateEvantEntryDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Evant ::
        public async Task<BaseResponseModel<IEnumerable<EvantDetialVM>>> GetAllEvantDetail()
        {
            try
            {
                var evantDetailList = await (from ed in _dbContext.EvantDetial
                                             join ev in _dbContext.Evant on ed.EvantId equals ev.EvantId
                                             select new EvantDetialVM
                                             {
                                                 EDetailId = ed.EvantId,
                                                 EvantId = ed.EvantId,
                                                 EvantName = ev.EvantName,
                                                 FieldTitle = ed.FieldTitle,
                                                 FiledType = ed.FiledType,
                                                 SequenceNo = ed.SequenceNo,
                                                 DefaultValue = ed.DefaultValue
                                             }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EvantDetialVM>>
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

        #region :: Get Evant By Id ::
        public async Task<BaseResponseObject<EvantDetialVM>> GetEvantDetailById(int EvantDetailId)
        {
            try
            {
                var evantDetail = await (from ed in _dbContext.EvantDetial
                                         join ev in _dbContext.Evant on ed.EvantId equals ev.EvantId
                                         where ed.EDetailId == EvantDetailId
                                         select new EvantDetialVM
                                         {
                                             EDetailId = ed.EvantId,
                                             EvantId = ed.EvantId,
                                             EvantName = ev.EvantName,
                                             FieldTitle = ed.FieldTitle,
                                             FiledType = ed.FiledType,
                                             SequenceNo = ed.SequenceNo,
                                             DefaultValue = ed.DefaultValue
                                         }).FirstOrDefaultAsync();

                return new BaseResponseObject<EvantDetialVM>
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

        #region :: Evant Entry ::

        #region :: Add/Update Evant Entry Detail ::
        public async Task<BaseResponse> AddUpdateEvantEntryDetail(AddUpdateEvantEntryVM entity)
        {
            try
            {
                EvantEntry? evantEntryDetail = await _dbContext.EvantEntry.FirstOrDefaultAsync(x => x.EEntryId == entity.EEntryId);

                bool isNewEvantEntryDetail = evantEntryDetail == null;

                if (isNewEvantEntryDetail)
                {
                    evantEntryDetail = new EvantEntry();
                    await _dbContext.EvantEntry.AddAsync(evantEntryDetail);
                }

                evantEntryDetail!.EvantId = entity.EvantId;
                evantEntryDetail.EDetailId = entity.EDetailId;
                evantEntryDetail.KishorId = entity.KishorId;
                evantEntryDetail.Value = entity.Value;
                evantEntryDetail.Completed = entity.Completed;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = isNewEvantEntryDetail,
                    Message = isNewEvantEntryDetail ? ResponseMessage.AddNewEvantEntryDetail : ResponseMessage.UpdateEvantEntryDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region ::Get All Evant ::
        public async Task<BaseResponseModel<IEnumerable<EvantEntryDetailVM>>> GetAllEvantEntryDetail()
        {
            try
            {
                var evantEntryDetailList = await (from ee in _dbContext.EvantEntry
                                                  join ev in _dbContext.Evant on ee.EvantId equals ev.EvantId
                                                  join ed in _dbContext.EvantDetial on ee.EDetailId equals ed.EDetailId
                                                  join k in _dbContext.Kishore on ee.KishorId equals k.KId
                                                  select new EvantEntryDetailVM
                                                  {
                                                      EEntryId = ee.EDetailId,
                                                      EvantId = ee.EvantId,
                                                      EvantName = ev.EvantName,
                                                      EDetailId = ee.EDetailId,
                                                      FieldTitle = ed.FieldTitle,
                                                      FieldType = ed.FiledType,
                                                      KishorId = ee.KishorId,
                                                      KishoreName = k.KishoreName + " " + k.FatherName + " " + k.SurName,
                                                      Value = ee.Value,
                                                      Completed = ee.Completed
                                                  }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<EvantEntryDetailVM>>
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

        #region :: Get Evant By Id ::
        public async Task<BaseResponseObject<EvantEntryDetailVM>> GetEvantEntryDetailById(int EvantDetailId)
        {
            try
            {
                var evantEntryDetail = await (from ee in _dbContext.EvantEntry
                                                  join ev in _dbContext.Evant on ee.EvantId equals ev.EvantId
                                                  join ed in _dbContext.EvantDetial on ee.EDetailId equals ed.EDetailId
                                                  join k in _dbContext.Kishore on ee.KishorId equals k.KId
                                                  select new EvantEntryDetailVM
                                                  {
                                                      EEntryId = ee.EDetailId,
                                                      EvantId = ee.EvantId,
                                                      EvantName = ev.EvantName,
                                                      EDetailId = ee.EDetailId,
                                                      FieldTitle = ed.FieldTitle,
                                                      FieldType = ed.FiledType,
                                                      KishorId = ee.KishorId,
                                                      KishoreName = k.KishoreName + " " + k.FatherName + " " + k.SurName,
                                                      Value = ee.Value,
                                                      Completed = ee.Completed
                                                  }).AsNoTracking().FirstOrDefaultAsync();


                return new BaseResponseObject<EvantEntryDetailVM>
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
