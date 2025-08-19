using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.EvantDetails;

namespace Eymyuvaman.Repository
{
    public interface IEvantRepository
    {
        Task<BaseResponse> AddUpdateEvant(AddUpdateEvantVM entity);
        Task<BaseResponseModel<IEnumerable<EvantVM>>> GetAllEvant();
        Task<BaseResponseObject<EvantVM>> GetEvantById(int EvantId);

        Task<BaseResponse> AddUpdateEvantAreaDetail(AddUpdateEvantAreaVM entity);
        Task<BaseResponseModel<IEnumerable<EvantAreaDetailVM>>> GetAllEvantAreaDetail();
        Task<BaseResponseObject<EvantAreaDetailVM>> GetEvantAreaDetailById(int EvantAreaId);

        Task<BaseResponse> AddUpdateEvantDetail(AddUpdateEvantDetialVM entity);
        Task<BaseResponseModel<IEnumerable<EvantDetialVM>>> GetAllEvantDetail();
        Task<BaseResponseObject<EvantDetialVM>> GetEvantDetailById(int EvantDetailId);

        Task<BaseResponse> AddUpdateEvantEntryDetail(AddUpdateEvantEntryVM entity);
        Task<BaseResponseModel<IEnumerable<EvantEntryDetailVM>>> GetAllEvantEntryDetail();
        Task<BaseResponseObject<EvantEntryDetailVM>> GetEvantEntryDetailById(int EvantDetailId);
    }
}
