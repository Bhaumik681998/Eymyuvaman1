using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.ViewModel.EventDetails
{
    public class AddUpdateEventVM
    {
        public int EventId { get; set; }
        [Required]
        public string? EventName { get; set; }
        [Required]
        public int Active { get; set; }
    }
}
