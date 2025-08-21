using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.City;
using Eymyuvaman.ViewModel.EventDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class CityService : ICityRespository
    {
        private readonly AppDBContext _dbContext;

        public CityService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update City 
        public async Task<BaseResponse> AddUpdateCity(AddUpdateCityVM entity)
        {
            try
            {
                bool isNewCity = false;

                City? citydetail = await _dbContext.City.FirstOrDefaultAsync(x => x.CityID == entity.CityID);
                if (citydetail == null)
                {
                    isNewCity = true;
                    citydetail = new City() { };

                    await _dbContext.City.AddAsync(citydetail);
                }

                citydetail.CityHead = entity.CityHead;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNewCity ? ResponseMessage.AddNewCityDetail : ResponseMessage.UpdateCityDetail
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All City ::
        public async Task<BaseResponseModel<IEnumerable<CityDetailVM>>> GetAllCityDetail()
        {
            try
            {
                var cityList = await _dbContext.City
                .Select(c => new CityDetailVM
                {
                    CityID = c.CityID,
                    CityHead = c.CityHead,
                }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<CityDetailVM>>
                {
                    Success = cityList.Any(),
                    Message = cityList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = cityList,
                    TotalRecored = cityList.Count
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
