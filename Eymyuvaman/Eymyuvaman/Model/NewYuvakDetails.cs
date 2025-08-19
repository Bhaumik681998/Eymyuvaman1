using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model
{
    public class NewYuvakDetails
    {
        [Key]
        public string? NewYuvakId { get; set; }
        public string? KishoreName { get; set; }
        public string? FatherName { get; set; }
        public string? SurName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Pincode { get; set; }
        public string? Phone { get; set; }
        public string? Area { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public bool? Status { get; set; }
    }
}
