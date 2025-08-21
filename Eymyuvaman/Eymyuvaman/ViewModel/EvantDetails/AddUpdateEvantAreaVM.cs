using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class AddUpdateEventAreaVM
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
