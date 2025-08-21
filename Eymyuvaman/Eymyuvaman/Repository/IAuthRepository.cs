using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.Auth;
using Eymyuvaman.ViewModel.UserMaster;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Repository
{
    public interface IAuthRepository
    {
        Task<BaseResponseObject<UserLoginResponseVM>> LoginUser(UserLoginVM entity);
        Task<BaseResponse> ChangePassword(int LoggedInUserId,ChangePasswordVM entity);
    }
}
