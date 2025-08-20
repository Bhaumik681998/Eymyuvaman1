using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.Zone;

namespace Eymyuvaman.Repository
{
    public interface IZoneRepository
    {
        Task<BaseResponse> AddUpdateZone(AddUpdateZonesVM entity);
        Task<BaseResponseModel<IEnumerable<ZonesDetailVM>>> GetAllZoneDetail();
    }
}
