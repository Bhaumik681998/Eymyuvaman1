using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.SabhaSession;

namespace Eymyuvaman.Repository
{
    public interface ISabhaSessionRepository
    {
        Task<BaseResponse> AddUpdateSabhaSession(AddUpdateSabhaSession entity);
        Task<BaseResponseModel<IEnumerable<SabhaSessionDetailVM>>> GetAllSabhaSessionDetail();
        Task<BaseResponseObject<SabhaSessionDetailVM>> GetSabhaSessionDetailById(int SabhaSessionId);
    }
}
