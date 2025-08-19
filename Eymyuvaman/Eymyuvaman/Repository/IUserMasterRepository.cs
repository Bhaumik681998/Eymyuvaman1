using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.UserMaster;

namespace Eymyuvaman.Repository
{
    public interface IUserMasterRepository
    {
        Task<BaseResponse> AddUpdateUserDetail(AddUpdateUserMasterVM entity);
        Task<BaseResponseModel<IEnumerable<UserMasterDetailsVM>>> GetAllUserDetail();
        Task<BaseResponseObject<UserMasterDetailsVM>> GetUserDetailById(int UserId);
    }
}
