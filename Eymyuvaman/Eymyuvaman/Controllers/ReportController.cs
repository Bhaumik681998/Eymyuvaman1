using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Report;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IReportRepository _reportRepository;
        private readonly AppDBContext _dbContext;
        public ReportController(IReportRepository reportRepository, AppDBContext dbContext)
        {
            _reportRepository = reportRepository;
            _dbContext = dbContext;
        }

        [HttpGet("Get-All-Yuvak-Details/{AreaId}/{DetailType}")]
        public async Task<IActionResult> GetAllYuvakDetails(int AreaId, int DetailType)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@AreaId", AreaId),
                    new SqlParameter("@DetailType", DetailType)
                };

                switch (DetailType)
                {
                    case 1:
                        var yuvakProfileDetail = await _dbContext.Set<YuvakProfileDetailVM>().FromSqlRaw("EXEC usp_YuvakDetailReport @AreaId, @DetailType", parameters).ToListAsync();

                        return Ok(new BaseResponseModel<IEnumerable<YuvakProfileDetailVM>>
                        {
                            Success = yuvakProfileDetail.Any(),
                            Message = yuvakProfileDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                            Data = yuvakProfileDetail,
                            TotalRecored = yuvakProfileDetail.Count
                        });

                    case 3:
                        var yuvakSatsangDetail = await _dbContext.Set<YuvakSatsangDetalVM>().FromSqlRaw("EXEC usp_YuvakDetailReport @AreaId, @DetailType", parameters).ToListAsync();

                        return Ok(new BaseResponseModel<IEnumerable<YuvakSatsangDetalVM>>
                        {
                            Success = yuvakSatsangDetail.Any(),
                            Message = yuvakSatsangDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                            Data = yuvakSatsangDetail,
                            TotalRecored = yuvakSatsangDetail.Count
                        });

                    case 4:
                        var yuvakSkillDetail = await _dbContext.Set<YuvakSkillDetailVM>().FromSqlRaw("EXEC usp_YuvakDetailReport @AreaId, @DetailType", parameters).ToListAsync();

                        return Ok(new BaseResponseModel<IEnumerable<YuvakSkillDetailVM>>
                        {
                            Success = yuvakSkillDetail.Any(),
                            Message = yuvakSkillDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                            Data = yuvakSkillDetail,
                            TotalRecored = yuvakSkillDetail.Count
                        });

                    case 5:
                        var yuvakFamilyDetail = await _dbContext.Set<FamilyMasterDetailVM>().FromSqlRaw("EXEC usp_YuvakDetailReport @AreaId, @DetailType", parameters).ToListAsync();

                        return Ok(new BaseResponseModel<IEnumerable<FamilyMasterDetailVM>>
                        {
                            Success = yuvakFamilyDetail.Any(),
                            Message = yuvakFamilyDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                            Data = yuvakFamilyDetail,
                            TotalRecored = yuvakFamilyDetail.Count
                        });

                    case 6:
                        var yuvakJobDetail = await _dbContext.Set<YuvakJobDetailVM>().FromSqlRaw("EXEC usp_YuvakDetailReport @AreaId, @DetailType", parameters).ToListAsync();

                        return Ok(new BaseResponseModel<IEnumerable<YuvakJobDetailVM>>
                        {
                            Success = yuvakJobDetail.Any(),
                            Message = yuvakJobDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                            Data = yuvakJobDetail,
                            TotalRecored = yuvakJobDetail.Count
                        });

                    default:
                        return Ok(new BaseResponseModel<IEnumerable<object>>
                        {
                            Success = false,
                            Message = "Invalid DetailType",
                            Data = new List<object>(),
                            TotalRecored = 0
                        });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { Success = false, Message = ex.Message });
            }
        }

        [HttpGet("Get-Birthday-Report-Details")]
        public async Task<BaseResponseModel<IEnumerable<BirthdayResponseVM>>> BirthdayReportVM([FromBody] BirthdayReportVM entity)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@All", "All"),
                    new SqlParameter("@SorDField", "DOB"),
                    new SqlParameter("@Sabhadate", entity.Sabhadate),
                    new SqlParameter("@BStartSabhadate", entity.BStartSabhadate),
                    new SqlParameter("@BEndSabhadate", entity.BEndSabhadate),
                    new SqlParameter("@AreaCode", entity.AreaCode)
                };
                var birthdayDetail = await _dbContext.BirthdayResponseVM.FromSqlRaw("EXEC RptBirthList @All,@SorDField,@Sabhadate, @BStartSabhadate, @BEndSabhadate, @AreaCode", parameters).ToListAsync();

                return new BaseResponseModel<IEnumerable<BirthdayResponseVM>>
                {
                    Success = birthdayDetail.Any(),
                    Message = birthdayDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = birthdayDetail,
                    TotalRecored = birthdayDetail.Count
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("Get-Attendance-Report-Details/{AreaCode}")]
        public async Task<BaseResponseModel<IEnumerable<AttendanceReportDetailVM>>> GetAttendanceReportDetails(string AreaCode)
        {
            try
            {
                var parameters = new[]
                {
                    new SqlParameter("@SorDField", ""),
                    new SqlParameter("@AreaCode", AreaCode) 
                };
                var attendanceDetail = await _dbContext.AttendanceReportDetailVM.FromSqlRaw("EXEC RptKishoreAttendanceList @SorDField,@AreaCode", parameters).ToListAsync();

                return new BaseResponseModel<IEnumerable<AttendanceReportDetailVM>>
                {
                    Success = attendanceDetail.Any(),
                    Message = attendanceDetail.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = attendanceDetail,
                    TotalRecored = attendanceDetail.Count
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region :: Active / InActive Yuvak ::
        [HttpGet("Get-All-Active-InActive-Yuvak")]
        public async Task<ActionResult> GetActiveInActiveYuvak()
        {
            var result = await _reportRepository.GetActiveInActiveYuvak();
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
