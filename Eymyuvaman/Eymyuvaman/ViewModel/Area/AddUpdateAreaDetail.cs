using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.Area
{
    public class AddUpdateAreaDetail
    {
        public int AreaID { get; set; }
        [Required]
        public int? ZoneID { get; set; }
        public string? AreaName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Mandir { get; set; }
        public string? Pincode { get; set; }
        public string? ImagePath { get; set; }
        public string? AreaCode { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }
        public string? UserEmail { get; set; }
        public string? UserMobile { get; set; }
        public bool? Status { get; set; }
    }
}

