using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.NewYuvakDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class YuvakController : BaseController
    {
        private readonly IYuvakRepository _yuvakRepository;
        public YuvakController(IYuvakRepository yuvakRepository)
        {
            _yuvakRepository = yuvakRepository;
        }

        [HttpPost("Add-Update-New-Yuvak-Detail")]
        public async Task<ActionResult> AddUpdateNewYuvakDetail([FromBody] AddUpdateNewYuvakDetail entity)
        {
            var result = await _yuvakRepository.AddUpdateNewYuvakDetail(entity);
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

        [HttpGet("Get-All-Yuvak-Detail")]
        public async Task<ActionResult> GetAllYuvakDetail()
        {
            var result = await _yuvakRepository.GetAllYuvakDetail();
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

        [HttpGet("Get-Yuvak-Detail-By-Id/{YuvakId}")]
        public async Task<ActionResult> GetYuvakDetailById(string YuvakId)
        {
            var result = await _yuvakRepository.GetYuvakDetailById(YuvakId);
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
