using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EvantDetails
{
    public class AddUpdateEvantAreaVM
    {
        public int Id { get; set; }
        [Required]
        public int EventId { get; set; }
        [Required]
        public int AreaId { get; set; }
        [Required]
        public int Flag { get; set; }
    }
}
