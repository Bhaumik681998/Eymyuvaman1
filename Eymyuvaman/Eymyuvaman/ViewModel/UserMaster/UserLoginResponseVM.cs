using Eymyuvaman.ViewModel.Designation;

namespace Eymyuvaman.ViewModel.UserMaster
{
    public class UserLoginResponseVM
    {
        public string? Token { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? KishoreName { get; set; }
        public int AreaId { get; set; }
        public List<UserDesignationVM>? Designation { get; set; } = new List<UserDesignationVM>();
        public DateTime ExpireAt { get; set; }
    }
    public class UserDesignationVM
    {
        public int DesigID { get; set; }
        public string? Designation { get; set; }
    }
}
