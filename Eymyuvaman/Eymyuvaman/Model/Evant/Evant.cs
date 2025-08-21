using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Event
{
    public class Evant
    {
        [Key]
        public int EvantId { get; set; }
        [Column("Evant")]
        public string? EventName { get; set; }
        public int Active { get; set; }
    }
}
