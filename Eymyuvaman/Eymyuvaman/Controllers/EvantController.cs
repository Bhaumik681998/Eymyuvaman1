using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EvantController : ControllerBase
    {
        private readonly IEvantRepository _evantRepository;
        public EvantController(IEvantRepository evantRepository)
        {
            _evantRepository = evantRepository;
        }

        #region :: Evant ::
        [HttpPost("Add-Update-Evant")]
        public async Task<ActionResult> AddUpdateEvant([FromBody] AddUpdateEvantVM entity)
        {
            var result = await _evantRepository.AddUpdateEvant(entity);
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

        [HttpGet("Get-All-Evant")]
        public async Task<ActionResult> GetAllEvant()
        {
            var result = await _evantRepository.GetAllEvant();
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

        [HttpGet("Get-Evant-By-Id/{EvantId}")]
        public async Task<ActionResult> GetEvantById(int EvantId)
        {
            var result = await _evantRepository.GetEvantById(EvantId);
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

        #region :: EvantArea ::
        [HttpPost("Add-Update-Evant-Area-Detail")]
        public async Task<ActionResult> AddUpdateEvantAreaDetail([FromBody] AddUpdateEvantAreaVM entity)
        {
            var result = await _evantRepository.AddUpdateEvantAreaDetail(entity);
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

        [HttpGet("Get-All-Evant-Area-Detail")]
        public async Task<ActionResult> GetAllEvantAreaDetail()
        {
            var result = await _evantRepository.GetAllEvantAreaDetail();
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

        [HttpGet("Get-Evant-Area-Detail-By-Id/{EvantAreaId}")]
        public async Task<ActionResult> GetEvantAreaDetailById(int EvantAreaId)
        {
            var result = await _evantRepository.GetEvantAreaDetailById(EvantAreaId);
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

        #region :: EvantDetial ::
        [HttpPost("Add-Update-Evant-Detail")]
        public async Task<ActionResult> AddUpdateEvantDetail([FromBody] AddUpdateEvantDetialVM entity)
        {
            var result = await _evantRepository.AddUpdateEvantDetail(entity);
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

        [HttpGet("Get-All-Evant-Detail")]
        public async Task<ActionResult> GetAllEvantDetail()
        {
            var result = await _evantRepository.GetAllEvantDetail();
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

        [HttpGet("Get-Evant-Detail-By-Id/{EvantDetailId}")]
        public async Task<ActionResult> GetEvantDetailById(int EvantDetailId)
        {
            var result = await _evantRepository.GetEvantDetailById(EvantDetailId);
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

        #region :: EvantEntry ::
        [HttpPost("Add-Update-Evant-Entry-Detail")]
        public async Task<ActionResult> AddUpdateEvantEntryDetail([FromBody] AddUpdateEvantEntryVM entity)
        {
            var result = await _evantRepository.AddUpdateEvantEntryDetail(entity);
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

        [HttpGet("Get-All-Evant-Entry-Detail")]
        public async Task<ActionResult> GetAllEvantEntryDetail()
        {
            var result = await _evantRepository.GetAllEvantEntryDetail();
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

        [HttpGet("Get-Evant-Entry-Detail-By-Id/{EvantEntryId}")]
        public async Task<ActionResult> GetEvantEntryDetailById(int EvantEntryId)
        {
            var result = await _evantRepository.GetEvantEntryDetailById(EvantEntryId);
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
