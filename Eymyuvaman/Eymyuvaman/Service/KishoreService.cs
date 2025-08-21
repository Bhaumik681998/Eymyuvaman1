using Eymyuvaman.CommonMethod;
using Eymyuvaman.Data;
using Eymyuvaman.Helper;
using Eymyuvaman.Model;
using Eymyuvaman.Repository;
using Eymyuvaman.ViewModel.Area;
using Eymyuvaman.ViewModel.Kishore;
using Eymyuvaman.ViewModel.Zone;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;

namespace Eymyuvaman.Service
{
    public class KishoreService : IKishoreRepository
    {
        private readonly AppDBContext _dbContext;

        public KishoreService(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region :: Add/Update Kishore Detail ::
        public async Task<BaseResponse> AddUpdateKishoreDetail(AddUpdateKishoreDetailVM entity)
        {
            try
            {
                var isExistEmailAndPhone = await _dbContext.Kishore.Where(x => x.Phone == entity.Phone || x.Email == entity.Email).FirstOrDefaultAsync();
                if (isExistEmailAndPhone != null)
                    return new BaseResponse { Success = false, Message = ResponseMessage.EmailAndPhoneAlreadyExist };

                Kishore? kishoreDetail = await _dbContext.Kishore.FirstOrDefaultAsync(k => k.KId == entity.KId);
                bool isNewkishore = kishoreDetail == null;
                if (isNewkishore)
                {
                    isNewkishore = true;
                    var areaCode = await _dbContext.Area.Where(a => a.AreaID == entity.AreaID).Select(a => a.AreaCode).FirstOrDefaultAsync();
                    if (string.IsNullOrEmpty(areaCode))
                        return new BaseResponse { Success = false, Message = ResponseMessage.InvalidAreaCode };

                    var lastKishoreId = await _dbContext.Kishore
                    .Where(k => k.AreaID == entity.AreaID && k.KishoreID.StartsWith(areaCode))
                    .OrderByDescending(k => k.KishoreID)
                    .Select(k => k.KishoreID)
                    .FirstOrDefaultAsync();

                    int nextNumber = 1;
                    if (!string.IsNullOrEmpty(lastKishoreId))
                    {
                        var numberPart = lastKishoreId.Substring(areaCode.Length);
                        if (int.TryParse(numberPart, out int lastNumber))
                            nextNumber = lastNumber + 1;
                    }
                    string newKishoreId = $"{areaCode}{nextNumber:D4}";

                    kishoreDetail = new Kishore()
                    {
                        KishoreID = newKishoreId,
                        AreaID = entity.AreaID,
                        RegistrationDate = DateTime.Now
                    };
                    await _dbContext.Kishore.AddAsync(kishoreDetail);
                }
                else
                {
                    kishoreDetail!.UpdatedDate = DateTime.Now;
                    _dbContext.Kishore.Update(kishoreDetail);
                }

                kishoreDetail.KishoreName = entity.KishoreName;
                kishoreDetail.FatherName = entity.FatherName;
                kishoreDetail.SurName = entity.SurName;
                kishoreDetail.Address1 = entity.Address1;
                kishoreDetail.Address2 = entity.Address2;
                kishoreDetail.Pincode = entity.Pincode;
                kishoreDetail.Gender = entity.Gender;
                kishoreDetail.DOB = entity.DOB;
                kishoreDetail.Email = entity.Email;
                kishoreDetail.Phone = entity.Phone;
                kishoreDetail.SecondaryPhone = entity.SecondaryPhone;
                kishoreDetail.Education = entity.Education;
                kishoreDetail.Occupation = entity.Occupation;
                kishoreDetail.Specialization = entity.Specialization;
                kishoreDetail.Hobbies = entity.Hobbies;
                kishoreDetail.Sports = entity.Sports;
                kishoreDetail.DesigID = entity.DesigID != null && entity.DesigID.Any() ? string.Join(",", entity.DesigID) : null;
                kishoreDetail.SamparkKishoreId = entity.SamparkKishoreId; //*
                kishoreDetail.KishoreStatus = entity.KishoreStatus;
                kishoreDetail.YearsInSatsang = entity.YearsInSatsang;
                kishoreDetail.VistarSabha = entity.VistarSabha;
                kishoreDetail.Puja = entity.Puja;
                kishoreDetail.Arti = entity.Arti;
                kishoreDetail.MaataPitaPranam = entity.MaataPitaPranam;
                kishoreDetail.SatsangReading = entity.SatsangReading;
                kishoreDetail.TShirtSize = entity.TShirtSize;
                kishoreDetail.OldKishoreId = entity.OldKishoreId;
                kishoreDetail.Area = entity.Area;
                kishoreDetail.NewKishoreId = entity.NewKishoreId; // *
                kishoreDetail.KImage = null;
                kishoreDetail.PrintFlag = entity.PrintFlag;
                kishoreDetail.Status = entity.Status;

                var (hash, salt) = PasswordHelper.HashPasswordWithSalt(entity.Password ?? string.Empty);
                kishoreDetail.Password = hash;
                kishoreDetail.PasswordSalt = salt;
                
                kishoreDetail.BloodGroup = entity.BloodGroup;
                kishoreDetail.IsShatabdiSevak = entity.IsShatabdiSevak;
                kishoreDetail.Comment = entity.Comment;

                await _dbContext.SaveChangesAsync();

                return new BaseResponse
                {
                    Success = true,
                    Message = isNewkishore ? ResponseMessage.AddNewKishoreDetail : ResponseMessage.UpdateKishoreDetail
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Getv All Kishore Detail ::
        public async Task<BaseResponseModel<IEnumerable<KishoreDetailVM>>> GetAllKishoreDetail()
        {
            try
            {

                var kishoreList = await _dbContext.Kishore.AsNoTracking().ToListAsync();

                var designations = await _dbContext.Designation.AsNoTracking().ToListAsync();

                var kishoreDetailsList = kishoreList.Select(k => new KishoreDetailVM
                {
                    KId = k.KId,
                    KishoreID = k.KishoreID,
                    AreaID = k.AreaID,
                    KishoreName = k.KishoreName,
                    FatherName = k.FatherName,
                    SurName = k.SurName,
                    Address1 = k.Address1,
                    Address2 = k.Address2,
                    Pincode = k.Pincode,
                    Gender = k.Gender,
                    DOB = k.DOB,
                    Email = k.Email,
                    Phone = k.Phone,
                    SecondaryPhone = k.SecondaryPhone,
                    Education = k.Education,
                    Occupation = k.Occupation,
                    Specialization = k.Specialization,
                    Hobbies = k.Hobbies,
                    Sports = k.Sports,
                    DesigID = k.DesigID?.Split(',').ToList(),
                    DesignationName = k.DesigID?.Split(',')
                        .Select(id => designations.FirstOrDefault(d => d.DesigID == Convert.ToInt32(id))?.DesignationName ?? string.Empty).Where(x => !string.IsNullOrWhiteSpace(x)).ToList(),
                    SamparkKishoreId = k.SamparkKishoreId,
                    RegistrationDate = k.RegistrationDate,
                    KishoreStatus = k.KishoreStatus,
                    YearsInSatsang = k.YearsInSatsang,
                    VistarSabha = k.VistarSabha,
                    Puja = k.Puja,
                    Arti = k.Arti,
                    MaataPitaPranam = k.MaataPitaPranam,
                    SatsangReading = k.SatsangReading,
                    TShirtSize = k.TShirtSize,
                    OldKishoreId = k.OldKishoreId,
                    Area = k.Area,
                    NewKishoreId = k.NewKishoreId,
                    PrintFlag = k.PrintFlag,
                    Status = k.Status,
                    BloodGroup = k.BloodGroup,
                    UpdatedDate = k.UpdatedDate,
                    IsShatabdiSevak = k.IsShatabdiSevak,
                    Comment = k.Comment
                }).ToList();


                return new BaseResponseModel<IEnumerable<KishoreDetailVM>>
                {
                    Success = kishoreDetailsList.Any(),
                    Message = kishoreDetailsList.Any() ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = kishoreDetailsList,
                    TotalRecored = kishoreDetailsList.Count
                };

            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region :: Get Kishore Detail By Id 
        public async Task<BaseResponseObject<KishoreDetailVM>> GetKishoreDetailById(int KishoreId)
        {
            try
            {
                var kishore = await _dbContext.Kishore.AsNoTracking().FirstOrDefaultAsync(x => x.KId == KishoreId);

                if (kishore == null)
                    return new BaseResponseObject<KishoreDetailVM> { Success = false, Message = ResponseMessage.NoDataFound, Data = null };

                var desigIds = kishore.DesigID?.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(id => Convert.ToInt32(id)).ToList() ?? new List<int>();

                var DesignationName = await _dbContext.Designation.AsNoTracking().Where(d => desigIds.Contains(d.DesigID))
                    .Select(d => d.DesignationName ?? string.Empty).Where(name => !string.IsNullOrWhiteSpace(name)).ToListAsync();

                var kishoreDetails = new KishoreDetailVM
                {
                    KId = kishore.KId,
                    KishoreID = kishore.KishoreID,
                    AreaID = kishore.AreaID,
                    KishoreName = kishore.KishoreName,
                    FatherName = kishore.FatherName,
                    SurName = kishore.SurName,
                    Address1 = kishore.Address1,
                    Address2 = kishore.Address2,
                    Pincode = kishore.Pincode,
                    Gender = kishore.Gender,
                    DOB = kishore.DOB,
                    Email = kishore.Email,
                    Phone = kishore.Phone,
                    SecondaryPhone = kishore.SecondaryPhone,
                    Education = kishore.Education,
                    Occupation = kishore.Occupation,
                    Specialization = kishore.Specialization,
                    Hobbies = kishore.Hobbies,
                    Sports = kishore.Sports,
                    DesigID = kishore.DesigID?.Split(',').ToList(),
                    DesignationName = DesignationName,
                    SamparkKishoreId = kishore.SamparkKishoreId,
                    RegistrationDate = kishore.RegistrationDate,
                    KishoreStatus = kishore.KishoreStatus,
                    YearsInSatsang = kishore.YearsInSatsang,
                    VistarSabha = kishore.VistarSabha,
                    Puja = kishore.Puja,
                    Arti = kishore.Arti,
                    MaataPitaPranam = kishore.MaataPitaPranam,
                    SatsangReading = kishore.SatsangReading,
                    TShirtSize = kishore.TShirtSize,
                    OldKishoreId = kishore.OldKishoreId,
                    Area = kishore.Area,
                    NewKishoreId = kishore.NewKishoreId,
                    PrintFlag = kishore.PrintFlag,
                    Status = kishore.Status,
                    BloodGroup = kishore.BloodGroup,
                    UpdatedDate = kishore.UpdatedDate,
                    IsShatabdiSevak = kishore.IsShatabdiSevak,
                    Comment = kishore.Comment
                };

                return new BaseResponseObject<KishoreDetailVM>
                {
                    Success = kishoreDetails != null,
                    Message = kishoreDetails != null ? ResponseMessage.DataRetrieved : ResponseMessage.NoDataFound,
                    Data = kishoreDetails
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
