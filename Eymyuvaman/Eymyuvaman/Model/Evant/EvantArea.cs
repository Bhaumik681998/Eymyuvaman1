using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model.Evant
{
    public class EvantArea
    {
        [Key]
        public int Id { get; set; }
        public int EventId { get; set; }
        public int AreaId { get; set; }
        public int Flag { get; set; }
    }
}
