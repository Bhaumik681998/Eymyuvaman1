using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.UserMaster
{
    public class AddUpdateUserMasterVM
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Mobile No must be 10 digits")]
        public string? MobileNo { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public bool? Status { get; set; }
    }
}
