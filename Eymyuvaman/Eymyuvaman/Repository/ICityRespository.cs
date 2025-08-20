using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.City;
using Eymyuvaman.ViewModel.EvantDetails;

namespace Eymyuvaman.Repository
{
    public interface ICityRespository
    {
        Task<BaseResponse> AddUpdateCity(AddUpdateCityVM entity);
        Task<BaseResponseModel<IEnumerable<CityDetailVM>>> GetAllCityDetail();
    }
}
