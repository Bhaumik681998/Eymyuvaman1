using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.City;
using Eymyuvaman.ViewModel.EventDetails;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRespository _cityRespository;

        public CityController(ICityRespository cityRespository)
        {
            _cityRespository = cityRespository;
        }

        [HttpPost("Add-Update-City")]
        public async Task<ActionResult> AddUpdateCity([FromBody] AddUpdateCityVM entity)
        {
            var result = await _cityRespository.AddUpdateCity(entity);
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

        [HttpGet("Get-All-City-Detail")]
        public async Task<ActionResult> GetAllCityDetail()
        {
            var result = await _cityRespository.GetAllCityDetail();
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
