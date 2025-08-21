using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.UserMaster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]

    public class UserMasterController : BaseController
    {
        private readonly IUserMasterRepository _userMasterRepository;

        public UserMasterController(IUserMasterRepository userMasterRepository)
        {
            _userMasterRepository = userMasterRepository;
        }

        [HttpPost("Add-Update-User-Detail")]
        public async Task<ActionResult> AddUpdateUserDetail([FromBody] AddUpdateUserMasterVM entity)
        {
            var result = await _userMasterRepository.AddUpdateUserDetail(entity);
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

        [HttpGet("Get-All-Users-Detail")]
        public async Task<ActionResult> GetAllUserDetail()
        {
            var result = await _userMasterRepository.GetAllUserDetail();
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
        [HttpGet("Get-Users-Detail-By-Id/{UserId}")]
        public async Task<ActionResult> GetUserDetailById(int UserId)
        {
            var result = await _userMasterRepository.GetUserDetailById(UserId);
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
