using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model
{
    public class NewYuvakSabhaAttend
    {
        [Key]
        public int AttendID { get; set; }
        public string? NewYuvakId { get; set; }
        public int SabhaSessionId { get; set; }
        public string? EntryTime { get; set; }
    }
}
