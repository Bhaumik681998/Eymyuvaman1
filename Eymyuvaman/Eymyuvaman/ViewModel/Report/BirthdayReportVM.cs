namespace Eymyuvaman.ViewModel.Report
{
    public class BirthdayReportVM
    {
        public DateTime? Sabhadate { get; set; }
        public DateTime? BStartSabhadate { get; set; }
        public DateTime? BEndSabhadate { get; set; }
        public string? AreaCode { get; set; }
    }

    public class BirthdayResponseVM
    {
        public string? YuvakName { get; set; }
        public string? Area { get; set; }
        public string? DOB { get; set; }
    }
}
