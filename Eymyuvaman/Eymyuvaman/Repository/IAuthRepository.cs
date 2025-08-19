using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.UserMaster;

namespace Eymyuvaman.Repository
{
    public interface IAuthRepository
    {
        Task<BaseResponseObject<UserLoginResponseVM>> LoginUser(UserLoginVM entity);
    }
}
