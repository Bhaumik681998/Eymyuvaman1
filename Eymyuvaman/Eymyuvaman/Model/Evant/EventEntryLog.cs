using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Evant
{
    public class EventEntryLog
    {
        [Key]
        public int Id { get; set; }
        public int EvantId { get; set; }
        public int EDetailId { get; set; }
        public long KishorId { get; set; }
        public string? Value { get; set; }
        public int Completed { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? EntryType { get; set; }
    }
}
