using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EventDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : BaseController
    {
        private readonly IEventRepository _eventRepository;
        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        #region :: Event ::
        [HttpPost("Add-Update-Event")]
        public async Task<ActionResult> AddUpdateEvent([FromBody] AddUpdateEventVM entity)
        {
            var result = await _eventRepository.AddUpdateEvent(entity);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-All-Event")]
        public async Task<ActionResult> GetAllEvent()
        {
            var result = await _eventRepository.GetAllEvent();
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-Event-By-Id/{EventId}")]
        public async Task<ActionResult> GetEventById(int EventId)
        {
            var result = await _eventRepository.GetEventById(EventId);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }
        #endregion

        #region :: EventArea ::
        [HttpPost("Add-Update-Event-Area-Detail")]
        public async Task<ActionResult> AddUpdateEventAreaDetail([FromBody] AddUpdateEventAreaVM entity)
        {
            var result = await _eventRepository.AddUpdateEventAreaDetail(entity);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-All-Event-Area-Detail")]
        public async Task<ActionResult> GetAllEventAreaDetail()
        {
            var result = await _eventRepository.GetAllEventAreaDetail();
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-Event-Area-Detail-By-Id/{EventAreaId}")]
        public async Task<ActionResult> GetEventAreaDetailById(int EventAreaId)
        {
            var result = await _eventRepository.GetEventAreaDetailById(EventAreaId);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }
        #endregion

        #region :: EventDetial ::
        [HttpPost("Add-Update-Event-Detail")]
        public async Task<ActionResult> AddUpdateEventDetail([FromBody] AddUpdateEventDetialVM entity)
        {
            var result = await _eventRepository.AddUpdateEventDetail(entity);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-All-Event-Detail")]
        public async Task<ActionResult> GetAllEventDetail()
        {
            var result = await _eventRepository.GetAllEventDetail();
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-Event-Detail-By-Id/{EventDetailId}")]
        public async Task<ActionResult> GetEventDetailById(int EventDetailId)
        {
            var result = await _eventRepository.GetEventDetailById(EventDetailId);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }
        #endregion

        #region :: EventEntry ::
        [HttpPost("Add-Update-Event-Entry-Detail")]
        public async Task<ActionResult> AddUpdateEventEntryDetail([FromBody] AddUpdateEventEntryVM entity)
        {
            var result = await _eventRepository.AddUpdateEventEntryDetail(entity);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-All-Event-Entry-Detail")]
        public async Task<ActionResult> GetAllEventEntryDetail()
        {
            var result = await _eventRepository.GetAllEventEntryDetail();
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }

        [HttpGet("Get-Event-Entry-Detail-By-Id/{EventEntryId}")]
        public async Task<ActionResult> GetEventEntryDetailById(int EventEntryId)
        {
            var result = await _eventRepository.GetEventEntryDetailById(EventEntryId);
            if (result.Success)
                return Ok(result);

            return StatusCode(StatusCodes.Status400BadRequest, new BaseResponseError
            {
                Success = result.Success,
                error = new ApiError
                {
                    code = 400,
                    Message = result.Message
                }
            });
        }
        #endregion
    }
}
