using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.NewYuvakSabhaAttend
{
    public class AddUpdateYuvakSabhaAttendVM
    {
        public int AttendID { get; set; }
        [Required]
        public string? NewYuvakId { get; set; }
        [Required]
        public int SabhaSessionId { get; set; }
        [Required]
        public string? EntryTime { get; set; }
    }
}
