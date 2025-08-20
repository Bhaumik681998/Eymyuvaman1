using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Designation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : Controller
    {
        private readonly IDesignationRepository _designationRepository;
        public DesignationController(IDesignationRepository designationRepository)
        {
            _designationRepository = designationRepository;
        }

        [HttpPost("Add-Update-Designation")]
        public async Task<ActionResult> AddUpdateDesignation([FromBody] AddUpdateDesignationVM entity)
        {
            var result = await _designationRepository.AddUpdateDesignation(entity);
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

        [HttpGet("Get-All-Designation")]
        public async Task<ActionResult> GetAllDesignationDetail()
        {
            var result = await _designationRepository.GetAllDesignationDetail();
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
