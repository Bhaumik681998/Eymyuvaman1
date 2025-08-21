using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.SabhaSession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class SabhaSessionController : BaseController
    {
        private readonly ISabhaSessionRepository _sabhaSessionRepository;
        public SabhaSessionController(ISabhaSessionRepository sabhaSessionRepository)
        {
            _sabhaSessionRepository = sabhaSessionRepository;
        }
        [HttpPost("Add-Update-Sabha-Session")]
        public async Task<ActionResult> AddUpdateSabhaSession([FromBody] AddUpdateSabhaSession entity)
        {
            var result = await _sabhaSessionRepository.AddUpdateSabhaSession(entity);
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
        [HttpGet("Get-All-Sabha-Session-Detail")]
        public async Task<ActionResult> GetAllSabhaSessionDetail()
        {
            var result = await _sabhaSessionRepository.GetAllSabhaSessionDetail();
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
        [HttpGet("Get-Sabha-Session-Detail-By-Id/{SabhaSessionId}")]
        public async Task<ActionResult> GetSabhaSessionDetailById(int SabhaSessionId)
        {
            var result = await _sabhaSessionRepository.GetSabhaSessionDetailById(SabhaSessionId);
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
