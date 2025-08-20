using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.Zone
{
    public class AddUpdateZonesVM
    {
        public int ZoneID { get; set; }
        [Required]
        public string? ZoneHead { get; set; }
        [Required]
        public int CityId { get; set; }
    }
}
