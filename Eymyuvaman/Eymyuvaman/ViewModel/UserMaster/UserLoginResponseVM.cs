namespace Eymyuvaman.ViewModel.UserMaster
{
    public class UserLoginResponseVM
    {
        public string? Token { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
