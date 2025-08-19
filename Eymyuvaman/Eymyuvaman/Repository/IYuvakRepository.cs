using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.NewYuvakDetails;

namespace Eymyuvaman.Repository
{
    public interface IYuvakRepository
    {
        Task<BaseResponse> AddUpdateNewYuvakDetail(AddUpdateNewYuvakDetail entity);
        Task<BaseResponseModel<IEnumerable<YuvakDetailVM>>> GetAllYuvakDetail();
        Task<BaseResponseObject<YuvakDetailVM>> GetYuvakDetailById(string YuvakId);
    }
}
