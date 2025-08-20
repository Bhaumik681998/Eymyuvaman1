using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Area;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _areaRepository;
        public AreaController(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }

        [HttpPost("Add-Update-Area-Detail")]
        public async Task<ActionResult> AddUpdateAreaDetail([FromBody] AddUpdateAreaDetail entity)
        {
            var result = await _areaRepository.AddUpdateAreaDetail(entity);
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

        [HttpGet("Get-All-Area-Detail")]
        public async Task<ActionResult> GetAllAreaDetail()
        {
            var result = await _areaRepository.GetAllAreaDetail();
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

        [HttpGet("Get-Area-Detail-By-Id/{AreaId}")]
        public async Task<ActionResult> GetAreaDetailById(int AreaId)
        {
            var result = await _areaRepository.GetAreaDetailById(AreaId);
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
    }
}
