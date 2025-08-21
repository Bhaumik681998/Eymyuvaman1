using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model
{
    public class UserMaster
    {
        [Key]
        public int Id { get; set; }
        public string? MobileNo { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? PasswordSalt { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? Status { get; set; }
    }
}
