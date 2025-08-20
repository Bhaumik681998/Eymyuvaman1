using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Kishore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KishoreController : ControllerBase
    {
        private readonly IKishoreRepository _kishoreRepository;
        public KishoreController(IKishoreRepository kishoreRepository)
        {
            _kishoreRepository = kishoreRepository;
        }

        [HttpPost("Add-Update-Kishore-Detail")]
        public async Task<ActionResult>  AddUpdateKishoreDetail([FromBody] AddUpdateKishoreDetailVM entity)
        {
            var result = await _kishoreRepository.AddUpdateKishoreDetail(entity);
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

        [HttpGet("Get-All-Kishore-Detail")]
        public async Task<ActionResult> GetAllKishoreDetail()
        {
            var result = await _kishoreRepository.GetAllKishoreDetail();
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
        [HttpGet("Get-Kishore-Detail-By-Id/{KishoreId}")]
        public async Task<ActionResult> GetKishoreDetailById(int KishoreId)
        {
            var result = await _kishoreRepository.GetKishoreDetailById(KishoreId);
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
