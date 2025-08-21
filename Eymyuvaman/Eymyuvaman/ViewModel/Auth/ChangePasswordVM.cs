using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.Auth
{
    public class ChangePasswordVM
    {        
        public string? UserName { get; set; }
        [Required]
        public string? OldPassword { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        public string? ConfirmPassword { get; set; }
    }
}
