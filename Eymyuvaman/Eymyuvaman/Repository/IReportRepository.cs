using Eymyuvaman.Helper;
using Eymyuvaman.ViewModel.Report;

namespace Eymyuvaman.Repository
{
    public interface IReportRepository
    {
        Task<BaseResponseModel<IEnumerable<ActiveInActiveYuvakDetailVM>>> GetActiveInActiveYuvak();
    }
}
