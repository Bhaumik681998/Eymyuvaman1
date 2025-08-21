using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.SabhaSession
{
    public class AddUpdateSabhaSession
    {
        public int Id { get; set; }
        [Required]
        public string? SessionTitle { get; set; }
        [Required]
        public string? Regular_Event { get; set; }
        [Required]
        public int Regular_Event_Id { get; set; }
        [Required]
        public DateTime? SabhaDate { get; set; }
        [Required]
        public string? StartTime { get; set; }
        [Required]
        public string? EndTime { get; set; }
        [Required]
        public string? TimeFlag { get; set; }
        public string? Description { get; set; }
        public double? Dislpay_Order { get; set; }
        [Required]
        public int? Active { get; set; }
        [Required]
        public string? SabhaCode { get; set; }
    }
}
