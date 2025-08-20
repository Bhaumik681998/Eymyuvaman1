using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.Area;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Repository
{
    public interface IAreaRepository
    {
        Task<BaseResponse> AddUpdateAreaDetail(AddUpdateAreaDetail entity);
        Task<BaseResponseModel<IEnumerable<AreaDetailVM>>> GetAllAreaDetail();
        Task<BaseResponseObject<AreaDetailVM>> GetAreaDetailById(int AreaId);
    }
}
