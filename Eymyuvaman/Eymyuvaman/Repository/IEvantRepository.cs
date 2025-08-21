using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.EventDetails;

namespace Eymyuvaman.Repository
{
    public interface IEventRepository
    {
        Task<BaseResponse> AddUpdateEvent(AddUpdateEventVM entity);
        Task<BaseResponseModel<IEnumerable<EventVM>>> GetAllEvent();
        Task<BaseResponseObject<EventVM>> GetEventById(int EventId);

        Task<BaseResponse> AddUpdateEventAreaDetail(AddUpdateEventAreaVM entity);
        Task<BaseResponseModel<IEnumerable<EventAreaDetailVM>>> GetAllEventAreaDetail();
        Task<BaseResponseObject<EventAreaDetailVM>> GetEventAreaDetailById(int EventAreaId);

        Task<BaseResponse> AddUpdateEventDetail(AddUpdateEventDetialVM entity);
        Task<BaseResponseModel<IEnumerable<EventDetialVM>>> GetAllEventDetail();
        Task<BaseResponseObject<EventDetialVM>> GetEventDetailById(int EventDetailId);

        Task<BaseResponse> AddUpdateEventEntryDetail(AddUpdateEventEntryVM entity);
        Task<BaseResponseModel<IEnumerable<EventEntryDetailVM>>> GetAllEventEntryDetail();
        Task<BaseResponseObject<EventEntryDetailVM>> GetEventEntryDetailById(int EventDetailId);
    }
}
