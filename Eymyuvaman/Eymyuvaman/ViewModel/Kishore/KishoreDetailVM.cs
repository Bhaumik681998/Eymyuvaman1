using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.Kishore
{
    public class KishoreDetailVM
    {
        public int KId { get; set; }
        public string? KishoreID { get; set; }
        public int AreaID { get; set; }
        public string? KishoreName { get; set; }
        public string? FatherName { get; set; }
        public string? SurName { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Pincode { get; set; }
        public string? Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? SecondaryPhone { get; set; }
        public string? Education { get; set; }
        public string? Occupation { get; set; }
        public string? Specialization { get; set; }
        public string? Hobbies { get; set; }
        public string? Sports { get; set; }
        //public string? ImagePath { get; set; }
        public List<string>? DesigID { get; set; }
        public List<string>? DesignationName { get; set; }
        public string? SamparkKishoreId { get; set; }
        public DateTime? RegistrationDate { get; set; }
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
        public string? PrintFlag { get; set; }
        public bool? Status { get; set; }
        public string? BloodGroup { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? IsShatabdiSevak { get; set; }
        public string? Comment { get; set; }
    }
}
