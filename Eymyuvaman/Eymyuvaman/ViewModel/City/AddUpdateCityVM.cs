using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.City
{
    public class AddUpdateCityVM
    {
        public int CityID { get; set; }
        [Required]
        public string? CityHead { get; set; }
    }
}
