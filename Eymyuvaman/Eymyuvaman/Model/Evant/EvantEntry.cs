using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Evant
{
    public class EvantEntry
    {
        [Key]
        public int EEntryId { get; set; }
        public int EvantId { get; set; }
        public int EDetailId { get; set; }
        public long KishorId { get; set; }
        public string? Value { get; set; }
        public int Completed { get; set; }
    }
}
