using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Model
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string? CityHead { get; set; }
    }
}
