using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.NewYuvakSabhaAttend;

namespace Eymyuvaman.Repository
{
    public interface INewYuvakSabhaAttendRepository
    {
        Task<BaseResponse> AddUpdateNewYuvakSabhaAttend(AddUpdateYuvakSabhaAttendVM entity);
        Task<BaseResponseModel<IEnumerable<YuvakSabhaAttendDetailVM>>> GetAllNewyuvakSabhaAttendDetail();
        Task<BaseResponseObject<YuvakSabhaAttendDetailVM>> GetNewyuvakSabhaAttendDetailById(int AttendId);
    }
}
