using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.Designation;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Repository
{
    public interface IDesignationRepository
    {
        Task<BaseResponse> AddUpdateDesignation(AddUpdateDesignationVM entity);
        Task<BaseResponseModel<IEnumerable<DesignationDetailVM>>> GetAllDesignationDetail();
    }
}
