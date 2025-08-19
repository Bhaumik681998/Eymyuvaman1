using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.NewYuvakSabhaAttend;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NewYuvakSabhaAttendController : ControllerBase
    {
        private readonly INewYuvakSabhaAttendRepository _newYuvakSabhaAttendRepository;
        public NewYuvakSabhaAttendController(INewYuvakSabhaAttendRepository newYuvakSabhaAttendRepository)
        {
            _newYuvakSabhaAttendRepository = newYuvakSabhaAttendRepository;
        }

        [HttpPost("Add-Update-New-Yuvak-Sabha-Attend")]
        public async Task<ActionResult> AddUpdateNewYuvakSabhaAttend([FromBody] AddUpdateYuvakSabhaAttendVM entity)
        {
            var result = await _newYuvakSabhaAttendRepository.AddUpdateNewYuvakSabhaAttend(entity);
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

        [HttpGet("Get-All-New-yuvak-Sabha-Attend-Detail")]
        public async Task<ActionResult> GetAllNewyuvakSabhaAttendDetail()
        {
            var result = await _newYuvakSabhaAttendRepository.GetAllNewyuvakSabhaAttendDetail();
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
        [HttpGet("Get-New-yuvak-Sabha-Attend-Detail-By-Id/{AttendId}")]
        public async Task<ActionResult> GetNewyuvakSabhaAttendDetailById(int AttendId)
        {
            var result = await _newYuvakSabhaAttendRepository.GetNewyuvakSabhaAttendDetailById(AttendId);
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
