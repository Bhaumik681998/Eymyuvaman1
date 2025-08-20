using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.EvantDetails;
using Eymyuvaman.ViewModel.Zone;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ZoneController : ControllerBase
    {
        private readonly IZoneRepository _zoneRepository;
        public ZoneController(IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
        }

        [HttpPost("Add-Update-Zone")]
        public async Task<ActionResult> AddUpdateZone(AddUpdateZonesVM entity)
        {
            var result = await _zoneRepository.AddUpdateZone(entity);
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

        [HttpGet("Get-All-Zone-Detail")]
        public async Task<ActionResult> GetAllZoneDetail()
        {
            var result = await _zoneRepository.GetAllZoneDetail();
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
