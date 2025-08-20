using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.Zone;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class ZoneService : IZoneRepository
    {
        private readonly AppDBContext _dbContext;

        public ZoneService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update Zone 
        public async Task<BaseResponse> AddUpdateZone(AddUpdateZonesVM entity)
        {
            try
            {
                bool isNewZone = false;

                Zones? zonedetail = await _dbContext.Zones.FirstOrDefaultAsync(x => x.ZoneID == entity.ZoneID);
                if (zonedetail == null)
                {
                    isNewZone = true;
                    zonedetail = new Zones() { };

                    await _dbContext.Zones.AddAsync(zonedetail);
                }

                zonedetail.ZoneHead = entity.ZoneHead;
                zonedetail.CityId = entity.CityId;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNewZone ? ResponseMessage.AddNewZonesDetail : ResponseMessage.UpdateZonesDetail
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All Zone ::
        public async Task<BaseResponseModel<IEnumerable<ZonesDetailVM>>> GetAllZoneDetail()
        {
            try
            {
                var zoneList = await (from z in _dbContext.Zones
                                      join c in _dbContext.City on z.CityId equals c.CityID
                                      select new ZonesDetailVM
                                      {
                                          ZoneID = z.ZoneID,
                                          ZoneHead = z.ZoneHead,
                                          CityId = z.CityId,
                                          CityName = c.CityHead
                                      }).AsNoTracking().ToListAsync();


                return new BaseResponseModel<IEnumerable<ZonesDetailVM>>
                {
                    Success = zoneList.Any(),
                    Message = zoneList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = zoneList,
                    TotalRecored = zoneList.Count
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
