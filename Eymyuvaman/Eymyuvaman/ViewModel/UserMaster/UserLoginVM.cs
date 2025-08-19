using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.UserMaster
{
    public class UserLoginVM
    {
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile No must be 10 digits")]
        public string? MobileNo { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
