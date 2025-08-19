namespace Eymyuvaman.ViewModel.SabhaSession
{
    public class SabhaSessionDetailVM
    {
        public int Id { get; set; }
        public string? SessionTitle { get; set; }
        public string? Regular_Evant { get; set; }
        public int Regular_Evant_Id { get; set; }
        public DateTime? SabhaDate { get; set; }
        public string? StartTime { get; set; }
        public string? EndTime { get; set; }
        public string? TimeFlag { get; set; }
        public string? Description { get; set; }
        public double? Dislpay_Order { get; set; }
        public int? Active { get; set; }
        public string? SabhaCode { get; set; }
    }
}
