using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Evant
{
    public class Evant
    {
        [Key]
        public int EvantId { get; set; }
        [Column("Evant")]
        public string? EvantName { get; set; }
        public int Active { get; set; }
    }
}
