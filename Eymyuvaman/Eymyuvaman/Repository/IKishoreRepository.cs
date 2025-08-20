using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.Kishore;

namespace Eymyuvaman.Repository
{
    public interface IKishoreRepository
    {
        Task<BaseResponse> AddUpdateKishoreDetail(AddUpdateKishoreDetailVM entity);
        Task<BaseResponseModel<IEnumerable<KishoreDetailVM>>> GetAllKishoreDetail();
        Task<BaseResponseObject<KishoreDetailVM>> GetKishoreDetailById(int KishoreId);
    }
}
