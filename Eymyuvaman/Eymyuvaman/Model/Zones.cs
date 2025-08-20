using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model
{
    public class Zones
    {
        [Key]
        public int ZoneID { get; set; }
        public string? ZoneHead { get; set; }
        public int CityId { get; set; }
    }
}
