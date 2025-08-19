using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.NewYuvakDetails
{
    public class AddUpdateNewYuvakDetail
    {
        public string? NewYuvakId { get; set; }
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
        public string? Phone { get; set; }
        [Required]
        public string? Area { get; set; }
        [Required]
        public DateTime? DOB { get; set; }
        [Required]
        public bool? Status { get; set; }
    }
}
