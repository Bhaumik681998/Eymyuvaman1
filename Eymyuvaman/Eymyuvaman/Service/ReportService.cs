using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Area;
using Eymyuvaman.ViewModel.Report;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class ReportService : IReportRepository
    {
        private readonly AppDBContext _dbContext;

        public ReportService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }


        #region :: Active/inActive Yuvak ::
        public async Task<BaseResponseModel<IEnumerable<ActiveInActiveYuvakDetailVM>>> GetActiveInActiveYuvak()
        {
            try
            {
                var allYuvakList = await _dbContext.Kishore.AsNoTracking().ToListAsync();

                var activeYuvakList = allYuvakList.Where(x => x.Status == true).Select(k => new ActiveYuvakDetailVM
                {
                    KishoreId = k.KId,
                    KishoreName = k.KishoreName,
                    FatherName = k.FatherName,
                    SureName = k.SurName,
                    MobileNo = k.Phone
                }).ToList();

                var inactiveYuvakList = allYuvakList.Where(x => x.Status == false).Select(k => new InActiveYuvakDetailVM
                {
                    KishoreId = k.KId,
                    KishoreName = k.KishoreName,
                    FatherName = k.FatherName,
                    SureName = k.SurName,
                    MobileNo = k.Phone
                }).ToList();

                var responseData = new ActiveInActiveYuvakDetailVM
                {
                    ActiveyuvakList = activeYuvakList,
                    InActiveyuvakList = inactiveYuvakList
                };

                return new BaseResponseModel<IEnumerable<ActiveInActiveYuvakDetailVM>>
                {
                    Success = true,
                    Message = ResponseMessage.DataRetrieved,
                    Data = new List<ActiveInActiveYuvakDetailVM> { responseData },
                    TotalRecored = activeYuvakList.Count + inactiveYuvakList.Count
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
