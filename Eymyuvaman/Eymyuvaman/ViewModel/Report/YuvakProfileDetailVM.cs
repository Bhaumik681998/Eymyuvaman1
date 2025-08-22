using System.ComponentModel.DataAnnotations.Schema;

namespace Eymyuvaman.ViewModel.Report
{
    public class YuvakProfileDetailVM
    {
        public string? YuvakName { get; set; }
        public string? Designation { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? BirthDate { get; set; }
        public string? Address { get; set; }
        public string? Pincode { get; set; }
        public string? BloodGroup { get; set; }
    }

    public class YuvakSatsangDetalVM
    {
        public string? YuvakName { get; set; }
        public string? Designation { get; set; }
        public string? TilakChandlo { get; set; }
        public string? SundaySabha { get; set; }
        public string? HomeThal { get; set; }
        public string? GharSabha { get; set; }
        public string? ReadVachanamrut { get; set; }
        public string? ReadSwaminiVato { get; set; }
        public string? MeetBapa { get; set; }
        public string? LetterToBapa { get; set; }
        public string? TelephoneToBapa { get; set; }
        public string? MukhpathVachanamrut { get; set; }
        public string? MukhpathSwaminiVato { get; set; }
        public string? MukhpathKirtans { get; set; }
        public string? ViewWebsite { get; set; }
        public string? YuvaTalim { get; set; }
        public string? TalimYear { get; set; }
        public string? SatsangBook { get; set; }
    }
    public class YuvakSkillDetailVM
    {
        public string? KishoreName { get; set; }
        public string? Designation { get; set; }
        public string? Dancing { get; set; }
        public string? Speaking { get; set; }
        public string? Singing { get; set; }
        public string? Art { get; set; }
        public string? Acting { get; set; }
    }
    public class FamilyMasterDetailVM
    {
        public string? YuvakName { get; set; }
        public string? Designation { get; set; }
        public int? SatsangSince { get; set; }
        public string? GharSabha { get; set; }
        public string? AreaSabha { get; set; }
        public string? SundaySabha { get; set; }
        public string? SwamiPrakash { get; set; }
        public string? SwamiBliss { get; set; }
        public string? BalPrakash { get; set; }
        public string? Premvati { get; set; }
        [Column("2Wheeler")]
        public string? TwoWheeler { get; set; }
        public string? Car { get; set; }
    }

    public class YuvakJobDetailVM
    {
        public string? YuvakName { get; set; }
        public string? Designation { get; set; }
        public string? Title { get; set; }
        public string? DateFrom { get; set; }
        public string? DateTo { get; set; }
        public string? Place { get; set; }
        public string? TimeFrom { get; set; }
        public string? TimeTo { get; set; }
    }
}
