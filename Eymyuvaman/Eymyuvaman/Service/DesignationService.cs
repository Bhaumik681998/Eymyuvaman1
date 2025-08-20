using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Designation;
using Eymyuvaman.ViewModel.Zone;
using Microsoft.EntityFrameworkCore;

namespace Eymyuvaman.Service
{
    public class DesignationService : IDesignationRepository
    {
        private readonly AppDBContext _dbContext;

        public DesignationService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update Designation ::
        public async Task<BaseResponse> AddUpdateDesignation(AddUpdateDesignationVM entity)
        {
            try
            {
                Designation? designationDetail = await _dbContext.Designation.FirstOrDefaultAsync(d => d.DesigID == entity.DesigID);
                bool isNewDesignation = designationDetail == null;

                if (isNewDesignation)
                {
                    isNewDesignation = true;
                    designationDetail = new Designation() { };

                    await _dbContext.Designation.AddAsync(designationDetail);
                }
                var lastIndex = await _dbContext.Designation.OrderByDescending(d => d.DesigID).Select(d => d.Indexof).FirstOrDefaultAsync();

                designationDetail.DesignationName = entity.Designation;

                designationDetail.Indexof = entity.Indexof == 0
                                    ? (lastIndex > 0 ? lastIndex + 1 : 1)
                                    : entity.Indexof;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNewDesignation ? ResponseMessage.AddNewDesignationDetail : ResponseMessage.UpdateDesignationDetail
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region :: Get All Designation ::
        public async Task<BaseResponseModel<IEnumerable<DesignationDetailVM>>> GetAllDesignationDetail()
        {
            try
            {
                var designationList = await (from d in _dbContext.Designation
                                      select new DesignationDetailVM
                                      {
                                          DesigID = d.DesigID,
                                          Designation = d.DesignationName,
                                          Indexof = d.Indexof
                                      }).AsNoTracking().ToListAsync();

                return new BaseResponseModel<IEnumerable<DesignationDetailVM>>
                {
                    Success = designationList.Any(),
                    Message = designationList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = designationList,
                    TotalRecored = designationList.Count
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
