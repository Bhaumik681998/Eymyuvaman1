using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.Kishore
{
    public class AddUpdateKishoreDetailVM
    {
        public int KId { get; set; }
        [Required]
        public int AreaID { get; set; }
        [Required]
        public string? KishoreName { get; set; }
        [Required]
        public string? FatherName { get; set; }
        [Required]
        public string? SurName { get; set; }
        [Required]
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Pincode { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string? Email { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Phone No must be 10 digits")]
        public string? Phone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Education { get; set; }
        public string? Occupation { get; set; }
        public string? Specialization { get; set; }
        public string? Hobbies { get; set; }
        public string? Sports { get; set; }
        //public string? ImagePath { get; set; }
        public List<string>? DesigID { get; set; } = null;
        public string? SamparkKishoreId { get; set; }
        public string? KishoreStatus { get; set; }
        public int? YearsInSatsang { get; set; }
        public string? VistarSabha { get; set; }
        public string? Puja { get; set; }
        public string? Arti { get; set; }
        public string? MaataPitaPranam { get; set; }
        public string? SatsangReading { get; set; }
        public string? TShirtSize { get; set; }
        public string? OldKishoreId { get; set; }
        public string? Area { get; set; }
        public string? NewKishoreId { get; set; }
        //public byte[]? KImage { get; set; }
        public string? PrintFlag { get; set; }
        public bool? Status { get; set; }
        [Required]
        public string? Password { get; set; }
        public string? BloodGroup { get; set; }
        public bool? IsShatabdiSevak { get; set; }
        public string? Comment { get; set; }
    }
}
